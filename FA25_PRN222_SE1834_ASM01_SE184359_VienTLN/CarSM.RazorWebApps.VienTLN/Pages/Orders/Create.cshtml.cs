using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarSM.Repositories.VienTLN.Models;
using CarSM.Services.VienTLN;

namespace CarSM.RazorWebApps.VienTLN.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrderVienTlnService _orderService;
        private readonly PaymentVienTlnService _paymentService;
        public CreateModel(IOrderVienTlnService orderService, PaymentVienTlnService paymentService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
        }

        public List<string> OrderTypes { get; set; } = new List<string> { "Rental", "Whosesale" };

        public IActionResult OnGet()
        {
            ViewData["OrderType"] = new SelectList();
            return Page();
        }

        [BindProperty]
        public OrderVienTln OrderVienTln { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
 
                return Page();
            }

            await _orderService.CreateAsync(OrderVienTln);

            return RedirectToPage("./Index");
        }
    }
}
