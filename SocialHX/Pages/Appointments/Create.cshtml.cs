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

namespace SocialHX.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public CreateModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var prescriber = await FindCurrentPrescriberAsync();
            if (!User.IsInRole("Admin"))
            {
                if (prescriber == null)
                {
                    ModelState.AddModelError(string.Empty, "No prescriber account matches your sign-in email.");
                }
                else
                {
                    ViewData["PrescriberID"] = _context.Prescriber
                       .Where(a => a.Email == prescriber.Email)
                       .Select(a => new SelectListItem
                       {
                           Value = a.Email,
                           Text = a.Email
                       }).ToList();
                }
            }

            PopulateSelectLists(prescriber);
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var prescriber = await FindCurrentPrescriberAsync();
            if (User.IsInRole("Admin"))
            {
                if (prescriber == null)
                {
                    ModelState.AddModelError(string.Empty, "No prescriber account matches your sign-in email.");
                }
                else
                {
                    Appointment.PrescriberID = prescriber.PrescriberID;
                }
            }

            if (!ModelState.IsValid)
            {
                PopulateSelectLists(prescriber);
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private Task<Prescriber?> FindCurrentPrescriberAsync()
        {
            var email = User.Identity?.Name;
            Console.Write(email.Trim().ToLower());
            return string.IsNullOrWhiteSpace(email)
                ? Task.FromResult<Prescriber?>(null)
                : _context.Prescriber.FirstOrDefaultAsync(
                    p => p.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        private void PopulateSelectLists(Prescriber? currentPrescriber)
        {
            var prescribers = User.IsInRole("Admin")
                ? _context.Prescriber.ToList()
                : currentPrescriber == null ? new List<Prescriber>() : new List<Prescriber> { currentPrescriber };

            ViewData["PrescriberID"] = new SelectList(prescribers, "Email", "Email");
            ViewData["StudentID"] = new SelectList(_context.Student, "Email", "Email");
        }
    }
}
