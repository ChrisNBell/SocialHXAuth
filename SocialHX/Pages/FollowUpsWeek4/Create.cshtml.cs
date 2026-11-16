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

               // prescription this follow-up is for with its student
        public Prescription? Prescription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Prescription = await LoadPrescriptionAsync(id);

            if (Prescription == null)
            {
                return RedirectToPage("/Prescriptions/Index");
            }

            ViewData["PID"] = id;
            return Page();
        }

        [BindProperty]
        public FollowUpWeek4 FollowUpWeek4 { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? PrescriptionID)
        {
            if (PrescriptionID == null)
            {
                return RedirectToPage("/Prescriptions/Index");
            }

            FollowUpWeek4.PrescriptionID = PrescriptionID.Value;

            if (!ModelState.IsValid)
            {
                Prescription = await LoadPrescriptionAsync(PrescriptionID);
                ViewData["PID"] = PrescriptionID;
                return Page();
            }

            var prescription = await _context.Prescription.FindAsync(FollowUpWeek4.PrescriptionID);
            if (prescription == null)
            {
                return NotFound();
            }

            _context.FollowUpWeek4.Add(FollowUpWeek4);
            prescription.Status = Status.Complete;
            await _context.SaveChangesAsync();

            if (FollowUpWeek4.Refill)
            {
                return RedirectToPage("/Prescriptions/Create", new { appt = prescription.AppointmentID });
            }

            return RedirectToPage("/Prescriptions/Details", new { id = FollowUpWeek4.PrescriptionID });
        }

        // admins see any prescription. prescribers only their own
        private async Task<Prescription?> LoadPrescriptionAsync(int? id)
        {
            if (id == null) return null;

            var query = _context.Prescription
                .Include(p => p.Appointment)
                    .ThenInclude(a => a!.Student)
                .Where(p => p.PrescriptionID == id);

            if (!User.IsInRole("Admin"))
            {
                var userEmail = User.Identity?.Name;
                query = query.Where(p => p.Appointment!.Prescriber!.Email == userEmail);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
