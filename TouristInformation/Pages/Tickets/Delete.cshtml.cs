using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TouristInformation.Data.Models;
using TouristInformation.Repositories.Contracts;

namespace TouristInformation.Pages.Tickets
{
    public class DeleteModel : PageModel
    {
        private readonly IGenericRepository<ReservedTicket> _repository;

        public DeleteModel(IGenericRepository<ReservedTicket> repository)
        {
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
            else 
            {
                ReservedTicket = reservedticket;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _repository.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
