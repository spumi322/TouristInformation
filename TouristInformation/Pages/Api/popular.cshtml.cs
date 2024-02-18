using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TouristInformation.Data.Models;

namespace TouristInformation.Pages.Api
{
    public class popularModel : PageModel
    {
        public readonly TouristInformationContext _context;

        public popularModel(TouristInformationContext context)
        {
            _context = context;
        }

        public IList<Attraction> Attractions { get; set; } = default!;

        public IActionResult OnGet()
        {
            var popular = _context.ReservedTickets
                .Include(a => a.Attr)
                .GroupBy(a => a.AttrId)
                .Select(group => new
                {
                    Attraction = group.First().Attr,
                    Sum = group.Sum(t => t.Quantity)
                })
                .OrderByDescending(a => a.Sum)
                .FirstOrDefault();
            if (popular == null)
            {
                return NotFound();
            }

            return new JsonResult(popular);
        }
    }
}
