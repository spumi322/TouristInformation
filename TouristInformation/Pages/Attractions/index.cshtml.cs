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
    public class indexModel : PageModel
    {
        private readonly IGenericRepository<Attraction> _repository;

        public indexModel(IGenericRepository<Attraction> repository)
        {
            this._repository = repository;
        }

        public IList<Attraction> Attractions { get;set; } = default!;

        public async Task OnGetAsync()
        {
                Attractions = await _repository.GetAll();
        }
    }
}
