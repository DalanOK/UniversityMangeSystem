using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityMangeSystem.Models;
using UniversityMangeSystem.Configurations;
using UniversityMangeSystem.Models.Configurations;

namespace UniversityMangeSystem.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<WorkEntity> Works { get; set; }
        public DbSet<GradeEntity> Grades {get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WorkConfiguration());
            builder.ApplyConfiguration(new GradeConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());

            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var student = new IdentityRole("student");
            student.NormalizedName = "student";

            var teacher = new IdentityRole("teacher");
            teacher.NormalizedName = "teacher";

            builder.Entity<IdentityRole>().HasData(admin,student,teacher);
        }
    }
}
