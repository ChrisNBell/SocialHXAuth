using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.Prescriptions
{
    public class DetailsModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public DetailsModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
            .Include(p => p.Student)
            .Include(p => p.Prescriber)
            .Include(p => p.Event1)
            .Include(p => p.Event2)
            .Include(p => p.Event3)
            .Include(p => p.Event4)
            .FirstOrDefaultAsync(m => m.PrescriptionID == id);

            if (prescription is not null)
            {
                Prescription = prescription;

                return Page();
            }

            return NotFound();
        }
    }
}
