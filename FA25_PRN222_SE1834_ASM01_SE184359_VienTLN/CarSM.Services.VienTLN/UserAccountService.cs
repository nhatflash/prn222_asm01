using CarSM.Repositories.VienTLN;
using CarSM.Repositories.VienTLN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSM.Services.VienTLN
{
    public class UserAccountService
    {
        private readonly UserAccountRepository _userAccountRepository;

        public UserAccountService(UserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccount> GetUserAccount(string username, string password)
        {
            try
            {
                return await _userAccountRepository.GetUserAccount(username, password);
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}
