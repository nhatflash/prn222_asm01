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
    public class UserAccountRepository : GenericRepository<UserAccount>
    {
        public UserAccountRepository(PRN222CarManagementDBContext context) : base(context)
        {
        }

        public async Task<UserAccount> GetUserAccount(string username, string password)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(x => x.Email == username && x.Password == password && x.IsActive);
        }
    }
}
