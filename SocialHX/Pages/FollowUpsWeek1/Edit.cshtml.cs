using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.FollowUpsWeek1
{
    public class EditModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public EditModel(SocialHX.Data.SocialHXContext context)
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

            var followupweek1 =  await _context.FollowUpWeek1.FirstOrDefaultAsync(m => m.FollowUpWeek1ID == id);
            if (followupweek1 == null)
            {
                return NotFound();
            }
            FollowUpWeek1 = followupweek1;
           ViewData["PrescriptionID"] = new SelectList(_context.Prescription, "PrescriptionID", "Event1Notes");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FollowUpWeek1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowUpWeek1Exists(FollowUpWeek1.FollowUpWeek1ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FollowUpWeek1Exists(int id)
        {
            return _context.FollowUpWeek1.Any(e => e.FollowUpWeek1ID == id);
        }
    }
}
