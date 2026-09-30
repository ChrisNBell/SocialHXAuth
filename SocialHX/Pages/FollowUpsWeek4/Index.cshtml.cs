using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.FollowUpsWeek4
{
    public class IndexModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public IndexModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public IList<FollowUpWeek4> FollowUpWeek4 { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FollowUpWeek4 = await _context.FollowUpWeek4
                .Include(f => f.Prescription).ToListAsync();
        }
    }
}
