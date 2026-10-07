using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.Referrals
{
    public class DeleteModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public DeleteModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Referral Referral { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referral = await _context.Referral_1.FirstOrDefaultAsync(m => m.ReferralID == id);

            if (referral is not null)
            {
                Referral = referral;

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

            var referral = await _context.Referral_1.FindAsync(id);
            if (referral != null)
            {
                Referral = referral;
                _context.Referral_1.Remove(Referral);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
