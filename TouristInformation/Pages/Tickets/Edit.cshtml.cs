using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristInformation.Data.Models;
using TouristInformation.Repositories.Contracts;

namespace TouristInformation.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly TouristInformationContext _context;
        private readonly IGenericRepository<ReservedTicket> _repository;

        public EditModel(TouristInformationContext context,
            IGenericRepository<ReservedTicket> repository)
        {
            this._context = context;
            this._repository = repository;
        }

        [BindProperty]
        public ReservedTicket ReservedTicket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservedticket = await _repository.Get(id.Value);
            if (reservedticket == null)
            {
                return NotFound();
            }

            ReservedTicket = reservedticket;
            
            ViewData["AttrId"] = new SelectList(_context.Attractions, "Id", "AttrName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _repository.Update(ReservedTicket);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await ReservedTicketExistsAsync(ReservedTicket.Id))
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

        private async Task<bool> ReservedTicketExistsAsync(int id)
        {
          return await _repository.Exists(id);
        }
    }
}
