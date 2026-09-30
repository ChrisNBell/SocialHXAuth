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
    public class DetailsModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public DetailsModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public FollowUpWeek1 FollowUpWeek1 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followupweek1 = await _context.FollowUpWeek1.FirstOrDefaultAsync(m => m.FollowUpWeek1ID == id);

            if (followupweek1 is not null)
            {
                FollowUpWeek1 = followupweek1;

                return Page();
            }

            return NotFound();
        }
    }
}
