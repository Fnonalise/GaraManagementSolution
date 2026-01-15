using GaraApp.DAL;
using GaraApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaraApp.BLL
{
    public class CustomerService
    {
        private CustomerRepository _repo = new CustomerRepository();

        public Task<List<Customer>> GetCustomersAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task AddCustomerAsync(Customer c)
        {
            if (c == null) throw new Exception("Dữ liệu không hợp lệ");
            if (string.IsNullOrWhiteSpace(c.FullName)) throw new Exception("Họ tên không được rỗng");
            return _repo.InsertAsync(c);
        }

        public Task UpdateCustomerAsync(Customer c)
        {
            if (c == null) throw new Exception("Dữ liệu không hợp lệ");
            if (c.CustomerId <= 0) throw new Exception("Chưa chọn khách hàng");
            if (string.IsNullOrWhiteSpace(c.FullName)) throw new Exception("Họ tên không được rỗng");
            return _repo.UpdateAsync(c);
        }

        public Task DeleteCustomerAsync(int id)
        {
            if (id <= 0) throw new Exception("ID không hợp lệ");
            return _repo.DeleteAsync(id);
        }

        public Task<List<Customer>> SearchCustomerAsync(string keyword)
        {
            return _repo.SearchAsync(keyword);
        }
    }
}
