using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarSM.Repositories.VienTLN.Models;
using CarSM.Services.VienTLN;

namespace CarSM.RazorWebApps.VienTLN.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderVienTlnService _orderVienTLNService;

        public IndexModel(IOrderVienTlnService orderVienTLNService)
        {
            _orderVienTLNService = orderVienTLNService;
        }

        public IList<OrderVienTln> OrderVienTln { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderVienTln = await _orderVienTLNService.GetAllAsync();
        }
    }
}
