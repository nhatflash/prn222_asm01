using CarSM.Repositories.VienTLN.Basic;
using CarSM.Repositories.VienTLN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSM.Repositories.VienTLN
{
    public class PaymentVienTlnRepository : GenericRepository<PaymentVienTln>
    {
        public PaymentVienTlnRepository(PRN222CarManagementDBContext context) : base(context)
        {
        }
    }
}
