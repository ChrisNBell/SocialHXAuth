using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialHX.Data;
using SocialHX.Models;

namespace SocialHX.Pages.Prescribers
{
    public class DetailsModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public DetailsModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public Prescriber Prescriber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriber = await _context.Prescriber.FirstOrDefaultAsync(m => m.PrescriberID == id);

            if (prescriber is not null)
            {
                Prescriber = prescriber;

                return Page();
            }

            return NotFound();
        }
    }
}
