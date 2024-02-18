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

namespace TouristInformation.Pages.Attractions
{
    public class EditModel : PageModel
    {
        private readonly IGenericRepository<Attraction> _repository;

        public EditModel(IGenericRepository<Attraction> repository)
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

            Attraction = attraction;

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
                await _repository.Update(Attraction);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await AttractionExistsAsync(Attraction.Id))
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

        private async Task<bool> AttractionExistsAsync(int id)
        {
          return await _repository.Exists(id);
        }
    }
}
