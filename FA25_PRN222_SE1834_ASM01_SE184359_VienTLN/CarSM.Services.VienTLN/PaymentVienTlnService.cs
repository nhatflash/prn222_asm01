using CarSM.Repositories.VienTLN;
using CarSM.Repositories.VienTLN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSM.Services.VienTLN
{
    public class PaymentVienTlnService
    {
        private readonly PaymentVienTlnRepository _paymentRepository;

        public PaymentVienTlnService(PaymentVienTlnRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<List<PaymentVienTln>> GetAllAsync()
        {
            try
            {
                return await _paymentRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                return new List<PaymentVienTln>();
            }
        }
    }
}
