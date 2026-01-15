using GaraApp.DAL;
using GaraApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaraApp.BLL
{
    public class PartService
    {
        private PartRepository _repo = new PartRepository();

        public Task<List<Part>> GetPartsAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<List<Part>> SearchPartAsync(string keyword)
        {
            return _repo.SearchAsync(keyword);
        }

        public Task<List<Part>> GetLowStockAsync()
        {
            return _repo.GetLowStockAsync();
        }

        public Task AddPartAsync(Part p)
        {
            if (p == null) throw new Exception("Dữ liệu không hợp lệ");
            if (string.IsNullOrWhiteSpace(p.PartName)) throw new Exception("Tên phụ tùng không được rỗng");
            if (p.UnitPrice < 0) throw new Exception("Đơn giá không hợp lệ");
            if (p.StockQty < 0) throw new Exception("Tồn kho không hợp lệ");
            if (p.MinQty < 0) throw new Exception("MinQty không hợp lệ");
            return _repo.InsertAsync(p);
        }

        public Task UpdatePartAsync(Part p)
        {
            if (p == null) throw new Exception("Dữ liệu không hợp lệ");
            if (p.PartId <= 0) throw new Exception("Chưa chọn phụ tùng");
            if (string.IsNullOrWhiteSpace(p.PartName)) throw new Exception("Tên phụ tùng không được rỗng");
            if (p.UnitPrice < 0) throw new Exception("Đơn giá không hợp lệ");
            if (p.StockQty < 0) throw new Exception("Tồn kho không hợp lệ");
            if (p.MinQty < 0) throw new Exception("MinQty không hợp lệ");
            return _repo.UpdateAsync(p);
        }

        public Task DeletePartAsync(int id)
        {
            if (id <= 0) throw new Exception("ID không hợp lệ");
            return _repo.DeleteAsync(id);
        }
    }
}
