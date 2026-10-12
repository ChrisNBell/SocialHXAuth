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

        public IActionResult OnGet(int? appt)
        {
            ViewData["Event1ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event2ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event3ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event4ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(Status)));

            if (appt == 0 || appt == null)
            {
                ViewData["AppointmentID"] = new SelectList(_context.Appointment, "AppointmentID", "AppointmentID");
            }
            else
            {
                ViewData["AppointmentID"] = _context.Appointment
                .Where(a => a.AppointmentID == appt)
                .Select(a => new SelectListItem
                {
                    Value = a.AppointmentID.ToString(),
                    Text = a.Student.Email + " (Appt " + a.AppointmentID + ")"
                }).ToList();
            }
            return Page();




        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
