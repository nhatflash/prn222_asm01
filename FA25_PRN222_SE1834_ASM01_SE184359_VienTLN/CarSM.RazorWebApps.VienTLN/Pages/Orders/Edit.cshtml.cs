using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarSM.Repositories.VienTLN.Models;
using CarSM.Services.VienTLN;

namespace CarSM.RazorWebApps.VienTLN.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly IOrderVienTlnService _orderService;
        

        public EditModel(IOrderVienTlnService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
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
            OrderVienTln = ordervientln;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                int records = await _orderService.UpdateAsync(OrderVienTln);
                if (records == 0) return Page();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderVienTlnExists(OrderVienTln.OrderVienTlnid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderVienTlnExists(long id)
        {
            return false;
        }
    }
}
