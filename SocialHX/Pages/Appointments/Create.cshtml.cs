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

        // student this appointment is for
        public Student? Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            Student = await _context.Student.FirstOrDefaultAsync(s => s.Email == id);

            // if no valid student = can't make an appointment. send back to referrals.
            if (Student == null)
            {
                return RedirectToPage("/Referrals/Index");
            }

            ViewData["PrescriberID"] = new SelectList(_context.Prescriber, "Email", "Email");
            ViewData["PID"] = id;
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string? StudentID)
        {
            Appointment.StudentID = StudentID ?? "";
            ModelState.Clear();
            TryValidateModel(Appointment);
            if (!ModelState.IsValid)
            {
                // reload what page needs so it doesn't break on a validation error
                Student = await _context.Student.FirstOrDefaultAsync(s => s.Email == StudentID);
                ViewData["PrescriberID"] = new SelectList(_context.Prescriber, "Email", "Email");
                ViewData["PID"] = StudentID;
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
