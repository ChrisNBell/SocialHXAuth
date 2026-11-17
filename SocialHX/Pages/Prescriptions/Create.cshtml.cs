using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.Prescriptions
{
    public class CreateModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public CreateModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

               // student this prescription is for looked up through the appointment
        public Student? Student { get; set; }

        public IActionResult OnGet(int? appt)
        {
            //  no appointment picker on this page so without one it cant be submitted
            if (appt == null || appt == 0)
            {
                return RedirectToPage("/Appointments/Index");
            }

            LoadPageData(appt.Value);
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? appt)
        {
            if (appt == null || appt == 0)
            {
                return RedirectToPage("/Appointments/Index");
            }

            Prescription.AppointmentID = appt.Value;
            Prescription.SetFollowUpDates();
            ModelState.Clear();
            TryValidateModel(Prescription);

            if (!ModelState.IsValid)
            {
                LoadPageData(appt.Value);
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void LoadPageData(int appt)
        {
            ViewData["Event1ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event2ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event3ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event4ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(Status)));
            ViewData["AID"] = appt;

            Student = _context.Appointment
                .Where(a => a.AppointmentID == appt)
                .Select(a => a.Student)
                .FirstOrDefault();
        }
    }
}
