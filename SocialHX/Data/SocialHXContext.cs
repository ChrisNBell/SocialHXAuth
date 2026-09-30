using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialHX.Models;

namespace SocialHX.Data
{
    public class SocialHXContext : DbContext
    {
        public SocialHXContext(DbContextOptions<SocialHXContext> options)
            : base(options)
        {
        }

        public DbSet<SocialHX.Models.Student> Student { get; set; } = default!;
        public DbSet<SocialHX.Models.Prescriber> Prescriber { get; set; } = default!;
        public DbSet<SocialHX.Models.Prescription> Prescription { get; set; } = default!;
        public DbSet<SocialHX.Models.Activity> Activity { get; set; } = default!;
        public DbSet<SocialHX.Models.FollowUpWeek1> FollowUpWeek1 { get; set; } = default!;
        public DbSet<SocialHX.Models.FollowUpWeek4> FollowUpWeek4 { get; set; } = default!;
    }
}
