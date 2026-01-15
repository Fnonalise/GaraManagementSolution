using GaraApp.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaraApp.DAL
{
    public class ServiceRepository
    {
        private readonly string _cn = DbHelper.ConnectionString;

        public async Task<List<Service>> GetAllAsync()
        {
            var list = new List<Service>();
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("SELECT * FROM Services ORDER BY ServiceName", conn))
            {
                cmd.CommandTimeout = 10;
                await conn.OpenAsync();
                using (var rd = await cmd.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        list.Add(Map(rd));
                    }
                }
            }
            return list;
        }

        public async Task<List<Service>> SearchAsync(string keyword)
        {
            var list = new List<Service>();
            string sql = @"SELECT * FROM Services 
                          WHERE ServiceName LIKE @kw 
                          ORDER BY ServiceName";
            
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                await conn.OpenAsync();
                using (var rd = await cmd.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        list.Add(Map(rd));
                    }
                }
            }
            return list;
        }

        public async Task InsertAsync(Service service)
        {
            string sql = @"INSERT INTO Services(ServiceName, BasePrice) 
                          VALUES(@ServiceName, @BasePrice)";
            
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                cmd.Parameters.AddWithValue("@BasePrice", service.BasePrice);
                
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Service service)
        {
            string sql = @"UPDATE Services 
                          SET ServiceName=@ServiceName, 
                              BasePrice=@BasePrice 
                          WHERE ServiceId=@ServiceId";
            
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@ServiceId", service.ServiceId);
                cmd.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                cmd.Parameters.AddWithValue("@BasePrice", service.BasePrice);
                
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("DELETE FROM Services WHERE ServiceId=@id", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@id", id);
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private static Service Map(SqlDataReader rd)
        {
            return new Service
            {
                ServiceId = Convert.ToInt32(rd["ServiceId"]),
                ServiceName = rd["ServiceName"].ToString() ?? "",
                BasePrice = Convert.ToDecimal(rd["BasePrice"])
            };
        }
    }
}
