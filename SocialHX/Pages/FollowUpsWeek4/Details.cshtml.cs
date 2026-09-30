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
    public class DetailsModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public DetailsModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public FollowUpWeek4 FollowUpWeek4 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followupweek4 = await _context.FollowUpWeek4.FirstOrDefaultAsync(m => m.FollowUpWeek4ID == id);

            if (followupweek4 is not null)
            {
                FollowUpWeek4 = followupweek4;

                return Page();
            }

            return NotFound();
        }
    }
}
