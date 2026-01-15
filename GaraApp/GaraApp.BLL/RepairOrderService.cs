using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaraApp.DAL;
using GaraApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaraApp.BLL
{
    public class RepairOrderService
    {
        public class PartLine
        {
            public int PartId { get; set; }
            public int Qty { get; set; }
            public decimal UnitPrice { get; set; }
        }

        public class ServiceLine
        {
            public int ServiceId { get; set; }
            public int Qty { get; set; }
            public decimal UnitPrice { get; set; }
        }

        /// <summary>
        /// TRANSACTION: tạo RepairOrder + details + trừ tồn kho Part
        /// </summary>
        public async Task<int> CreateRepairOrderAsync(
            int carId,
            string symptom,
            int odometer,
            List<ServiceLine> services,
            List<PartLine> parts)
        {
            using var ctx = DbContextFactory.Create();
            using var tx = await ctx.Database.BeginTransactionAsync();

            try
            {
                // 1) Check tồn kho trước (phòng thiếu hàng)
                var partIds = parts.Select(p => p.PartId).Distinct().ToList();
                var partEntities = await ctx.Parts.Where(p => partIds.Contains(p.PartId)).ToListAsync();

                foreach (var line in parts)
                {
                    var part = partEntities.FirstOrDefault(p => p.PartId == line.PartId)
                               ?? throw new Exception($"PartId={line.PartId} not found.");

                    if (part.StockQty < line.Qty)
                        throw new Exception($"Không đủ tồn kho: {part.PartName}. Tồn={part.StockQty}, cần={line.Qty}");
                }

                // 2) Tạo phiếu
                var order = new RepairOrder
                {
                    CarId = carId,
                    ReceiveDate = DateTime.Now,
                    Symptom = symptom ?? "",
                    Odometer = odometer,
                    Status = "OPEN",
                };

                await ctx.RepairOrders.AddAsync(order);
                await ctx.SaveChangesAsync(); // lấy RepairOrderId

                // 3) Add dịch vụ
                foreach (var s in services)
                {
                    var lineTotal = s.UnitPrice * s.Qty;
                    await ctx.RepairServiceDetails.AddAsync(new RepairServiceDetail
                    {
                        RepairOrderId = order.RepairOrderId,
                        ServiceId = s.ServiceId,
                        Qty = s.Qty,
                        UnitPrice = s.UnitPrice,
                        LineTotal = lineTotal
                    });
                }

                // 4) Add phụ tùng + trừ kho
                foreach (var p in parts)
                {
                    var lineTotal = p.UnitPrice * p.Qty;
                    await ctx.RepairPartDetails.AddAsync(new RepairPartDetail
                    {
                        RepairOrderId = order.RepairOrderId,
                        PartId = p.PartId,
                        Qty = p.Qty,
                        UnitPrice = p.UnitPrice,
                        LineTotal = lineTotal
                    });

                    var part = partEntities.First(x => x.PartId == p.PartId);
                    part.StockQty -= p.Qty; // TRỪ TỒN
                    ctx.Parts.Update(part);
                }

                // 5) Update tổng tiền
                order.TotalAmount =
                    services.Sum(x => x.UnitPrice * x.Qty) +
                    parts.Sum(x => x.UnitPrice * x.Qty);

                ctx.RepairOrders.Update(order);

                await ctx.SaveChangesAsync();
                await tx.CommitAsync();

                return order.RepairOrderId;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
}
