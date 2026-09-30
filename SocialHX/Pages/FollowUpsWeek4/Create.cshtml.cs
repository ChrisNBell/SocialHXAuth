using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.FollowUpsWeek4
{
    public class CreateModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public CreateModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PrescriptionID"] = new SelectList(_context.Prescription, "PrescriptionID", "Event1Notes");
            return Page();
        }

        [BindProperty]
        public FollowUpWeek4 FollowUpWeek4 { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FollowUpWeek4.Add(FollowUpWeek4);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
