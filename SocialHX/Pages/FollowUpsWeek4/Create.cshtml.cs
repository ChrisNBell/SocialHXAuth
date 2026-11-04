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

        public IActionResult OnGet(int? id)
        {
            var prescription = User.IsInRole("Admin") ?
             _context.Prescription
                .Include(p => p.Appointment)
                    .ThenInclude(p => p.Student)
                    .ToList()
            :
            _context.Prescription
                .Include(p => p.Appointment)
                    .ThenInclude(p => p.Student)
                    .Where(p => p.Appointment.Prescriber.Email == User.Identity.Name)
                    .ToList();



            ViewData["PID"] = id;
            ViewData["PrescriptionID"] = prescription
                .Where(a => a.PrescriptionID == id)
                .Select(a => new SelectListItem
                {
                    Value = a.PrescriptionID.ToString(),
                    Text = "Prescription #" + a.PrescriptionID.ToString() + " " + a.Appointment.Student.Email
                }).ToList();

            return Page();
        }

        [BindProperty]
        public FollowUpWeek4 FollowUpWeek4 { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? PrescriptionID)
        {
            FollowUpWeek4.PrescriptionID = (int)PrescriptionID;
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
