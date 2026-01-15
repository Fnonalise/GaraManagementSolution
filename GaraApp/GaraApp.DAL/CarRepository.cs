using GaraApp.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace GaraApp.DAL
{
    public class CarRepository
    {
        private readonly string _cn = ConfigurationManager.ConnectionStrings["GaraDb"].ConnectionString;

        public async Task<List<Car>> GetAllAsync()
        {
            var list = new List<Car>();
            string sql = @"
SELECT c.CarId, c.LicensePlate, c.Brand, c.Model, c.[Year], c.CustomerId,
       cu.FullName, cu.Phone, cu.Address
FROM Cars c
JOIN Customers cu ON cu.CustomerId = c.CustomerId
ORDER BY c.CarId DESC";

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand(sql, conn))
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

        public async Task<List<Car>> GetByCustomerAsync(int customerId)
        {
            var list = new List<Car>();
            string sql = @"
SELECT c.CarId, c.LicensePlate, c.Brand, c.Model, c.[Year], c.CustomerId,
       cu.FullName, cu.Phone, cu.Address
FROM Cars c
JOIN Customers cu ON cu.CustomerId = c.CustomerId
WHERE c.CustomerId = @CustomerId
ORDER BY c.CarId DESC";

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                await conn.OpenAsync();
                using (var rd = await cmd.ExecuteReaderAsync())
                {
                    while (await rd.ReadAsync())
                        list.Add(Map(rd));
                }
            }

            return list;
        }

        public async Task<List<Car>> SearchAsync(string keyword)
        {
            var list = new List<Car>();
            string sql = @"
SELECT c.CarId, c.LicensePlate, c.Brand, c.Model, c.[Year], c.CustomerId,
       cu.FullName, cu.Phone, cu.Address
FROM Cars c
JOIN Customers cu ON cu.CustomerId = c.CustomerId
WHERE c.LicensePlate LIKE @kw
   OR c.Brand LIKE @kw
   OR c.Model LIKE @kw
   OR cu.FullName LIKE @kw
ORDER BY c.CarId DESC";

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand(sql, conn))
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

        public async Task InsertAsync(Car car)
        {
            string sql = @"INSERT INTO Cars(LicensePlate, Brand, Model, [Year], CustomerId)
VALUES (@LicensePlate, @Brand, @Model, @Year, @CustomerId)";

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@LicensePlate", car.LicensePlate);
                cmd.Parameters.AddWithValue("@Brand", (object)car.Brand ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Model", (object)car.Model ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@CustomerId", car.CustomerId);

                await conn.OpenAsync();
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
                {
                    throw new Exception("Biển số đã tồn tại!");
                }
            }
        }

        public async Task UpdateAsync(Car car)
        {
            string sql = @"
UPDATE Cars
SET LicensePlate=@LicensePlate, Brand=@Brand, Model=@Model, [Year]=@Year, CustomerId=@CustomerId
WHERE CarId=@CarId";

            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@CarId", car.CarId);
                cmd.Parameters.AddWithValue("@LicensePlate", car.LicensePlate);
                cmd.Parameters.AddWithValue("@Brand", (object)car.Brand ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Model", (object)car.Model ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@CustomerId", car.CustomerId);

                await conn.OpenAsync();
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
                {
                    throw new Exception("Biển số đã tồn tại!");
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = new SqlConnection(_cn))
            using (var cmd = new SqlCommand("DELETE FROM Cars WHERE CarId=@id", conn))
            {
                cmd.CommandTimeout = 10;
                cmd.Parameters.AddWithValue("@id", id);
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private static Car Map(SqlDataReader rd)
        {
            int year = rd["Year"] == DBNull.Value ? 0 : Convert.ToInt32(rd["Year"]);

            return new Car
            {
                CarId = Convert.ToInt32(rd["CarId"]),
                LicensePlate = rd["LicensePlate"].ToString(),
                Brand = rd["Brand"] == DBNull.Value ? null : rd["Brand"].ToString(),
                Model = rd["Model"] == DBNull.Value ? null : rd["Model"].ToString(),
                Year = year,
                CustomerId = Convert.ToInt32(rd["CustomerId"]),
                Customer = new Customer
                {
                    CustomerId = Convert.ToInt32(rd["CustomerId"]),
                    FullName = rd["FullName"].ToString(),
                    Phone = rd["Phone"] == DBNull.Value ? null : rd["Phone"].ToString(),
                    Address = rd["Address"] == DBNull.Value ? null : rd["Address"].ToString()
                }
            };
        }
    }
}
