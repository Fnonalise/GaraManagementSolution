using GaraApp.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace GaraApp.DAL
{
    public class CustomerRepository
    {
        private readonly string _cn = ConfigurationManager.ConnectionStrings["GaraDb"].ConnectionString;

        public async Task<List<Customer>> GetAllAsync()
        {
            var list = new List<Customer>();

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("SELECT CustomerId, FullName, Phone, Address FROM Customers ORDER BY CustomerId DESC", conn))
            {
                cmd.CommandTimeout = 10;
                await conn.OpenAsync();

                using (var rd = await cmd.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        list.Add(new Customer
                        {
                            CustomerId = Convert.ToInt32(rd["CustomerId"]),
                            FullName = rd["FullName"].ToString(),
                            Phone = rd["Phone"] == DBNull.Value ? null : rd["Phone"].ToString(),
                            Address = rd["Address"] == DBNull.Value ? null : rd["Address"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public async Task InsertAsync(Customer c)
        {
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("INSERT INTO Customers(FullName, Phone, Address) VALUES(@FullName,@Phone,@Address)", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@FullName", c.FullName);
                cmd.Parameters.AddWithValue("@Phone", (object)c.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)c.Address ?? DBNull.Value);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Customer c)
        {
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("UPDATE Customers SET FullName=@FullName, Phone=@Phone, Address=@Address WHERE CustomerId=@CustomerId", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@CustomerId", c.CustomerId);
                cmd.Parameters.AddWithValue("@FullName", c.FullName);
                cmd.Parameters.AddWithValue("@Phone", (object)c.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)c.Address ?? DBNull.Value);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId=@id", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@id", id);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<Customer>> SearchAsync(string keyword)
        {
            var list = new List<Customer>();

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("SELECT CustomerId, FullName, Phone, Address FROM Customers WHERE FullName LIKE @kw OR Phone LIKE @kw ORDER BY CustomerId DESC", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                await conn.OpenAsync();
                using (var rd = await cmd.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                    {
                        list.Add(new Customer
                        {
                            CustomerId = Convert.ToInt32(rd["CustomerId"]),
                            FullName = rd["FullName"].ToString(),
                            Phone = rd["Phone"] == DBNull.Value ? null : rd["Phone"].ToString(),
                            Address = rd["Address"] == DBNull.Value ? null : rd["Address"].ToString()
                        });
                    }
                }
            }

            return list;
        }
    }
}
