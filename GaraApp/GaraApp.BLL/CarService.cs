using GaraApp.DAL;
using GaraApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaraApp.BLL
{
    public class CarService
    {
        private CarRepository _repo = new CarRepository();

        public Task<List<Car>> GetCarsAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<List<Car>> GetByCustomerAsync(int customerId)
        {
            return _repo.GetByCustomerAsync(customerId);
        }

        public Task<List<Car>> SearchCarAsync(string keyword)
        {
            return _repo.SearchAsync(keyword);
        }

        public Task AddCarAsync(Car car)
        {
            if (car == null) throw new Exception("Dữ liệu không hợp lệ");
            if (string.IsNullOrWhiteSpace(car.LicensePlate)) throw new Exception("Biển số không được rỗng");
            if (car.CustomerId <= 0) throw new Exception("Vui lòng chọn chủ xe");
            return _repo.InsertAsync(car);
        }

        public Task UpdateCarAsync(Car car)
        {
            if (car == null) throw new Exception("Dữ liệu không hợp lệ");
            if (car.CarId <= 0) throw new Exception("Chưa chọn xe");
            if (string.IsNullOrWhiteSpace(car.LicensePlate)) throw new Exception("Biển số không được rỗng");
            if (car.CustomerId <= 0) throw new Exception("Vui lòng chọn chủ xe");
            return _repo.UpdateAsync(car);
        }

        public Task DeleteCarAsync(int id)
        {
            if (id <= 0) throw new Exception("ID không hợp lệ");
            return _repo.DeleteAsync(id);
        }
    }
}
