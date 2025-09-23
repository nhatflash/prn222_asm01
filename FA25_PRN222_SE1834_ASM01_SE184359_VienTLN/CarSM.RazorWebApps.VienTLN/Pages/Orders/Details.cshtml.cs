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
    public class DetailsModel : PageModel
    {
        private readonly IOrderVienTlnService _orderService;

        public DetailsModel(IOrderVienTlnService orderService)
        {
            _orderService = orderService;
        }

        public OrderVienTln OrderVienTln { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordervientln = await _orderService.GetByIdAsync(id.Value);
            if (ordervientln == null)
            {
                return NotFound();
            }
            else
            {
                OrderVienTln = ordervientln;
            }
            return Page();
        }
    }
}
