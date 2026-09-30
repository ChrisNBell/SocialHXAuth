using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.FollowUpsWeek1
{
    public class IndexModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public IndexModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public IList<FollowUpWeek1> FollowUpWeek1 { get; set; } = default!;

        public async Task OnGetAsync()
        {
            FollowUpWeek1 = await _context.FollowUpWeek1
            .Include(f => f.Prescription)
                .ThenInclude(p => p.Student)
            .ToListAsync();
        }
    }
}
