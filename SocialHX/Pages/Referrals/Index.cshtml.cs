using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.Referrals
{
    public class IndexModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public IndexModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public IList<Referral> Referral { get;set; } = default!;
        public string AppointmentFilter { get; private set; } = "without";

        public async Task OnGetAsync(string? appointmentFilter)
        {
            AppointmentFilter = appointmentFilter switch
            {
                "all" => "all",
                "with" => "with",
                _ => "without"
            };

            var referrals = _context.Referral.AsQueryable();
            if (AppointmentFilter == "with")
            {
                referrals = referrals.Where(r => _context.Appointment.Any(a => a.StudentID == r.StudentID));
            }
            else if (AppointmentFilter == "without")
            {
                referrals = referrals.Where(r => !_context.Appointment.Any(a => a.StudentID == r.StudentID));
            }

            Referral = await referrals.Include(r => r.Student).ToListAsync();
        }
    }
}
