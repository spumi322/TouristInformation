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
    public class DetailsModel : PageModel
    {
        private readonly IGenericRepository<Attraction> _repository;

        public DetailsModel(IGenericRepository<Attraction> repository)
        {
            this._repository = repository;
        }

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
    }
}
