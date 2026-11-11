using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.Referrals
{
    public class CreateModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public CreateModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Referral Referral { get; set; } = default!;

        // The student this referral is for (display only not bound from the form)
        public Student? Student { get; set; }

        public IActionResult OnGet(string? id)
        {
            Student = _context.Student.FirstOrDefault(s => s.Email == id);

            if (Student == null)
            {
                return RedirectToPage("/Students/Create");
            }

            LoadDropdowns();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload what the page needs or it breaks
                Student = _context.Student.FirstOrDefault(s => s.Email == Referral.StudentID);
                LoadDropdowns();
                return Page();
            }

            _context.Referral.Add(Referral);
            await _context.SaveChangesAsync();

            return RedirectToPage("/ThankYou/thankyoureferral");
        }

        private void LoadDropdowns()
        {
            ViewData["SubmitterList"] = new SelectList(Enum.GetValues(typeof(Submitter)));
            ViewData["ConcernsList"] = new SelectList(Enum.GetValues(typeof(Concerns)));
        }
    }
}