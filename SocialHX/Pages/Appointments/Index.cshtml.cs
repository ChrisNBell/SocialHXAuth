using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public IndexModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get; set; } = default!;
        public string PrescriptionFilter { get; private set; } = "without";

        public async Task OnGetAsync(string? prescriptionFilter)
        {

            PrescriptionFilter = prescriptionFilter switch
            {
                "all" => "all",
                "with" => "with",
                _ => "without"
            };

            var appointments = _context.Appointment.AsQueryable();
            if (PrescriptionFilter == "with")
            {
                appointments = appointments.Where(r => _context.Prescription.Any(a => a.AppointmentID == r.AppointmentID));
            }
            else if (PrescriptionFilter == "without")
            {
                appointments = appointments.Where(r => !_context.Prescription.Any(a => a.AppointmentID == r.AppointmentID));
            }

            Appointment = User.IsInRole("Admin") ?
            await appointments
            .Include(a => a.Prescriber)
            .Include(a => a.Student).ToListAsync()
            :
            await appointments
            .Include(a => a.Prescriber)
            .Include(a => a.Student)
            .Where(a => a.Prescriber.Email == User.Identity.Name)
            .ToListAsync();
        }
    }
}
