using CarSM.Repositories.VienTLN.Basic;
using CarSM.Repositories.VienTLN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSM.Repositories.VienTLN
{
    public class OrderVienTlnRepository : GenericRepository<OrderVienTln>
    {
        public OrderVienTlnRepository(PRN222CarManagementDBContext context) : base(context)
        {
        }

        
        public new async Task<List<OrderVienTln>> GetAllAsync()
        {
            return await _context.OrderVienTlns.Include(x => x.PaymentVienTlns).ToListAsync();
        }

        public async Task<OrderVienTln> GetByOrderIdAsync(long id)
        {
            return await _context.OrderVienTlns.Include(x => x.PaymentVienTlns).FirstOrDefaultAsync(x => x.OrderVienTlnid == id);
        }

        public async Task<List<OrderVienTln>> SearchAsync(string orderType, decimal? amount, bool? isRefunded)
        {
            return await _context.OrderVienTlns.Include(x => x.PaymentVienTlns).Where(x => (x.OrderType.Contains(orderType) || string.IsNullOrEmpty(orderType)) || (x.TotalAmount == amount) || (x.IsRefunded == isRefunded)).ToListAsync();
        }

        public async Task<List<OrderVienTln>> SearchAsync(string orderType, decimal? amount, string bankCode)
        {
            return await _context.OrderVienTlns.Include(x => x.PaymentVienTlns).Where(x => (x.OrderType.Contains(orderType) || string.IsNullOrEmpty(orderType)) && (x.TotalAmount == amount) && (string.IsNullOrEmpty(bankCode) || x.PaymentVienTlns.Any(p => p.BankCode.Contains(bankCode))))
            .ToListAsync();
        }
    }
}
