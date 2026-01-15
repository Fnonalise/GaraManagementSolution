using GaraApp.DAL;
using GaraApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaraApp.BLL
{
    public class ServiceService
    {
        private ServiceRepository _repo = new ServiceRepository();

        public Task<List<Service>> GetServicesAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<List<Service>> SearchServiceAsync(string keyword)
        {
            return _repo.SearchAsync(keyword);
        }

        public Task AddServiceAsync(Service service)
        {
            if (service == null) throw new Exception("D? li?u không h?p l?");
            if (string.IsNullOrWhiteSpace(service.ServiceName)) throw new Exception("Tên d?ch v? không ???c r?ng");
            if (service.BasePrice < 0) throw new Exception("Giá d?ch v? không h?p l?");
            return _repo.InsertAsync(service);
        }

        public Task UpdateServiceAsync(Service service)
        {
            if (service == null) throw new Exception("D? li?u không h?p l?");
            if (service.ServiceId <= 0) throw new Exception("Ch?a ch?n d?ch v?");
            if (string.IsNullOrWhiteSpace(service.ServiceName)) throw new Exception("Tên d?ch v? không ???c r?ng");
            if (service.BasePrice < 0) throw new Exception("Giá d?ch v? không h?p l?");
            return _repo.UpdateAsync(service);
        }

        public Task DeleteServiceAsync(int id)
        {
            if (id <= 0) throw new Exception("ID không h?p l?");
            return _repo.DeleteAsync(id);
        }
    }
}
