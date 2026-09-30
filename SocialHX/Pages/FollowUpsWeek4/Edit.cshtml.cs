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

namespace SocialHX.Pages.FollowUpsWeek4
{
    public class EditModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public EditModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FollowUpWeek4 FollowUpWeek4 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followupweek4 =  await _context.FollowUpWeek4.FirstOrDefaultAsync(m => m.FollowUpWeek4ID == id);
            if (followupweek4 == null)
            {
                return NotFound();
            }
            FollowUpWeek4 = followupweek4;
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

            _context.Attach(FollowUpWeek4).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowUpWeek4Exists(FollowUpWeek4.FollowUpWeek4ID))
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

        private bool FollowUpWeek4Exists(int id)
        {
            return _context.FollowUpWeek4.Any(e => e.FollowUpWeek4ID == id);
        }
    }
}
