using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TouristInformation.Data.Models;
using TouristInformation.Repositories.Contracts;

namespace TouristInformation.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly TouristInformationContext _context;
        private readonly IGenericRepository<ReservedTicket> _repository;

        public CreateModel(TouristInformationContext context, 
            IGenericRepository<ReservedTicket> repository)
        {
            this._context = context;
            this._repository = repository;
        }

        public IActionResult OnGet()
        {
        ViewData["AttrId"] = new SelectList(_context.Attractions
            .Where(x => x.Category != "Restaurant"),
            "Id",
            "AttrName");

            return Page();
        }

        [BindProperty]
        public ReservedTicket ReservedTicket { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
          
          if (!ModelState.IsValid || ReservedTicket == null)
            {
                return Page();
            }


            await _repository.Insert(ReservedTicket);

            return RedirectToPage("./Index");
        }
    }
}
