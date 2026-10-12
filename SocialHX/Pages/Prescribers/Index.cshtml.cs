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
    public class IndexModel : PageModel
    {
        private readonly SocialHX.Data.SocialHXContext _context;

        public IndexModel(SocialHX.Data.SocialHXContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DepartmentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Prescriber> Prescriber { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DepartmentSort = sortOrder == "Department" ? "department_desc" : "Department";

            CurrentFilter = searchString;

            IQueryable<Prescriber> prescriberIQ = from s in _context.Prescriber
                                                  select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                prescriberIQ = prescriberIQ.Where(s => s.Name.Contains(searchString)
                                       || s.Department.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    prescriberIQ = prescriberIQ.OrderByDescending(s => s.Name);
                    break;
                case "Department":
                    prescriberIQ = prescriberIQ.OrderBy(s => s.Department);
                    break;
                case "department_desc":
                    prescriberIQ = prescriberIQ.OrderByDescending(s => s.Department);
                    break;
                default:
                    prescriberIQ = prescriberIQ.OrderBy(s => s.Name);
                    break;
            }

            Prescriber = await prescriberIQ.AsNoTracking().ToListAsync();
        }
    }
}
