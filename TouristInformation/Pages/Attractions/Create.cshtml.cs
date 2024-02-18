using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TouristInformation.Data.Models;
using TouristInformation.Repositories.Contracts;

namespace TouristInformation.Pages.Attractions
{
    public class CreateModel : PageModel
    {
        private readonly IGenericRepository<Attraction> _repository;

        public CreateModel(IGenericRepository<Attraction> repository)
        {
            this._repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Attraction Attraction { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Attraction == null)
            {
                return Page();
            }

            await _repository.Insert(Attraction);
  

            return RedirectToPage("./Index");
        }
    }
}
