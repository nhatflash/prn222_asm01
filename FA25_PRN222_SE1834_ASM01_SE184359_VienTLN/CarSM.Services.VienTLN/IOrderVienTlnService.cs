using CarSM.Repositories.VienTLN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSM.Services.VienTLN
{
    public interface IOrderVienTlnService
    {
        Task<List<OrderVienTln>> GetAllAsync();

        Task<OrderVienTln> GetByIdAsync(long id);

        Task<List<OrderVienTln>> SearchAsync(string orderType, decimal? amount, string bankCode);

        Task<int> CreateAsync(OrderVienTln order);

        Task<int> UpdateAsync(OrderVienTln order);

        Task<bool> DeleteAsync(long id);

        Task SaveChangesAsync();
    }
}
