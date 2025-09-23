using CarSM.Repositories.VienTLN;
using CarSM.Repositories.VienTLN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSM.Services.VienTLN
{
    public class OrderVienTlnService : IOrderVienTlnService
    {
        private readonly OrderVienTlnRepository _orderRepository;

        public OrderVienTlnService(OrderVienTlnRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> CreateAsync(OrderVienTln order)
        {
            try
            {
                return await _orderRepository.CreateAsync(order);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var item = await _orderRepository.GetByIdAsync(id);
                if (item == null) return false;
                return await _orderRepository.RemoveAsync(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<OrderVienTln>> GetAllAsync()
        {
            try
            {
                return await _orderRepository.GetAllAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<OrderVienTln> GetByIdAsync(long id)
        {
            try
            {
                return await _orderRepository.GetByOrderIdAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _orderRepository.SaveAsync();
        }

        public async Task<List<OrderVienTln>> SearchAsync(string orderType, decimal? amount, string bankCode)
        {
            try
            {
                return await _orderRepository.SearchAsync(orderType, amount, bankCode);
            }
            catch (Exception e)
            {
                return new List<OrderVienTln>();
            }
        }

        public async Task<int> UpdateAsync(OrderVienTln order)
        {
            try
            {
                return await _orderRepository.UpdateAsync(order);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
