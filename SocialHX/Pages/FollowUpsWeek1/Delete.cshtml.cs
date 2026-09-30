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
    public class DeleteModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public DeleteModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followupweek1 = await _context.FollowUpWeek1.FindAsync(id);
            if (followupweek1 != null)
            {
                FollowUpWeek1 = followupweek1;
                _context.FollowUpWeek1.Remove(FollowUpWeek1);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
