using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol;
using TouristInformation.Data.Models;

namespace TouristInformation.Pages.Api
{
    public class budgetModel : PageModel
    {
        public readonly TouristInformationContext _context;
        public budgetModel(TouristInformationContext context)
        {
            _context = context;
        }

        public IList<Attraction> Attractions { get; set; } = default!;

        public IActionResult OnGet()
        {
            var cheapestAttractionByCategory = new List<Attraction>();
            var categories = new List<string>();

            foreach (var attraction in _context.Attractions)
            {
                categories.Add(attraction.Category);
                categories = categories.Distinct().ToList();

            }

            foreach (var category in categories)
            {
                var minPrice = _context.Attractions
                    .Where(a => a.Category == category)
                    .OrderBy(a => a.Price)
                    .FirstOrDefault();

                if (minPrice != null)
                {
                    cheapestAttractionByCategory.Add(minPrice);
                }
            }

            return new JsonResult(cheapestAttractionByCategory);

        }
    }
}
