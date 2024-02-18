using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TouristInformation.Data.Models;
using TouristInformation.Repositories.Contracts;

namespace TouristInformation.Pages.Attractions
{
    public class DeleteModel : PageModel
    {
        private readonly IGenericRepository<Attraction> _repository;

        public DeleteModel(IGenericRepository<Attraction> repository)
        {
            this._repository = repository;
        }

        [BindProperty]
        public Attraction Attraction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attraction = await _repository.Get(id.Value);

            if (attraction == null)
            {
                return NotFound();
            }
            else 
            {
                Attraction = attraction;
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
