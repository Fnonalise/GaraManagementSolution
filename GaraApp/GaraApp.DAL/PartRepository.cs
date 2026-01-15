using GaraApp.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace GaraApp.DAL
{
    public class PartRepository
    {
        private readonly string _cn = ConfigurationManager.ConnectionStrings["GaraDb"].ConnectionString;

        public async Task<List<Part>> GetAllAsync()
        {
            var list = new List<Part>();

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("SELECT PartId, PartName, Unit, UnitPrice, StockQty, MinQty FROM Parts ORDER BY PartId DESC", conn))
            {
                cmd.CommandTimeout = 10;
                await conn.OpenAsync();

                using (var rd = await cmd.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                        list.Add(Map(rd));
                }
            }

            return list;
        }

        public async Task<List<Part>> SearchAsync(string keyword)
        {
            var list = new List<Part>();

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("SELECT PartId, PartName, Unit, UnitPrice, StockQty, MinQty FROM Parts WHERE PartName LIKE @kw ORDER BY PartId DESC", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                await conn.OpenAsync();
                using (var rd = await cmd.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                        list.Add(Map(rd));
                }
            }

            return list;
        }

        public async Task<List<Part>> GetLowStockAsync()
        {
            var list = new List<Part>();

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("SELECT PartId, PartName, Unit, UnitPrice, StockQty, MinQty FROM Parts WHERE StockQty <= MinQty ORDER BY PartId DESC", conn))
            {
                cmd.CommandTimeout = 10;
                await conn.OpenAsync();

                using (var rd = await cmd.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                        list.Add(Map(rd));
                }
            }

            return list;
        }

        public async Task InsertAsync(Part p)
        {
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("INSERT INTO Parts(PartName, Unit, UnitPrice, StockQty, MinQty) VALUES(@PartName,@Unit,@UnitPrice,@StockQty,@MinQty)", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@PartName", p.PartName);
                cmd.Parameters.AddWithValue("@Unit", p.Unit);
                cmd.Parameters.AddWithValue("@UnitPrice", p.UnitPrice);
                cmd.Parameters.AddWithValue("@StockQty", p.StockQty);
                cmd.Parameters.AddWithValue("@MinQty", p.MinQty);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Part p)
        {
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("UPDATE Parts SET PartName=@PartName, Unit=@Unit, UnitPrice=@UnitPrice, StockQty=@StockQty, MinQty=@MinQty WHERE PartId=@PartId", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@PartId", p.PartId);
                cmd.Parameters.AddWithValue("@PartName", p.PartName);
                cmd.Parameters.AddWithValue("@Unit", p.Unit);
                cmd.Parameters.AddWithValue("@UnitPrice", p.UnitPrice);
                cmd.Parameters.AddWithValue("@StockQty", p.StockQty);
                cmd.Parameters.AddWithValue("@MinQty", p.MinQty);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("DELETE FROM Parts WHERE PartId=@id", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@id", id);
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private static Part Map(SqlDataReader rd)
        {
            return new Part
            {
                PartId = Convert.ToInt32(rd["PartId"]),
                PartName = rd["PartName"].ToString(),
                Unit = rd["Unit"].ToString(),
                UnitPrice = Convert.ToDecimal(rd["UnitPrice"]),
                StockQty = Convert.ToInt32(rd["StockQty"]),
                MinQty = Convert.ToInt32(rd["MinQty"])
            };
        }
    }
}
