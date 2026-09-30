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

namespace SocialHX.Pages.Prescriptions
{
    public class EditModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public EditModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescription == null)
            {
                return NotFound();
            }
            Prescription = prescription;
            ViewData["Event1ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event2ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event3ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["Event4ID"] = new SelectList(_context.Activity, "ActivityID", "Name");
            ViewData["PrescriberID"] = new SelectList(_context.Prescriber, "PrescriberID", "Email");
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Email");
            ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(Status)));
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Prescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionExists(Prescription.PrescriptionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescription.Any(e => e.PrescriptionID == id);
        }
    }
}
