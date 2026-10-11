using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
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
            var prescription = _context.Prescription
                .Include(f => f.Appointment)
                .ThenInclude(f => f.Student)
                .ToList();

            ViewData["PrescriptionID"] = new SelectList(_context.Prescription, "PrescriptionID", "Appointment.Student.Email");
            return Page();
        }

        [BindProperty]
        public FollowUpWeek4 FollowUpWeek4 { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var id = await _context.Prescription.FindAsync(FollowUpWeek4.PrescriptionID);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FollowUpWeek4.Add(FollowUpWeek4);
            await _context.SaveChangesAsync();

            id.Status = Status.Complete;
            await _context.SaveChangesAsync();

            if (FollowUpWeek4.Refill == true)
            {
                Console.WriteLine("Trying to refill");
                return RedirectToPage("/Prescriptions/Create", new { appt = id.AppointmentID });
            }

            return RedirectToPage("./Index");
        }
    }
}
