using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TouristInformation.Data.Models;

namespace TouristInformation.Pages.Tickets
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TouristInformationContext _context;

        public IndexModel(TouristInformationContext context)
        {
            _context = context;
        }

        public IList<ReservedTicket> ReservedTickets { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReservedTickets != null)
            {
                ReservedTickets = await _context.ReservedTickets
                .Include(r => r.Attr).ToListAsync();
            }
        }
    }
}
