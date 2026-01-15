using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaraApp.DAL;
using Microsoft.EntityFrameworkCore;

namespace GaraApp.BLL
{
    public class ReportService
    {
        public class RevenueByDayRow
        {
            public DateTime Day { get; set; }
            public decimal Revenue { get; set; }
            public int Orders { get; set; }
        }

        public async Task<List<RevenueByDayRow>> GetRevenueByDayAsync(DateTime from, DateTime to)
        {
            using var ctx = DbContextFactory.Create();
            to = to.Date.AddDays(1); // inclusive end day

            var query = ctx.RepairOrders.AsNoTracking()
                .Where(x => x.ReceiveDate >= from.Date && x.ReceiveDate < to && x.Status != "CANCELED");

            return await query
                .GroupBy(x => x.ReceiveDate.Date)
                .Select(g => new RevenueByDayRow
                {
                    Day = g.Key,
                    Revenue = g.Sum(x => x.TotalAmount),
                    Orders = g.Count()
                })
                .OrderBy(x => x.Day)
                .ToListAsync();
        }
    }
}
