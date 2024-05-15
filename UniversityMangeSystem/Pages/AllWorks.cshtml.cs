using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityMangeSystem.Models;
using UniversityMangeSystem.Services;

namespace UniversityMangeSystem.Pages
{
    public class AllWorksModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AllWorksModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<WorkEntity> UserWorks { get; set; }
        public List<string> Grades { get; set; }
        public List<string> TeachersNames { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var teacherUserIds = _context.UserRoles
           .Where(ur => ur.RoleId == "e62d5bf8-1c03-4ef2-b3f8-0eea9ba79ec7")
           .Select(ur => ur.UserId)
           .ToList();

            // Отримуємо імена користувачів з роллю "teacher"
            var teacherUserNames = _context.Users
                .Where(u => teacherUserIds.Contains(u.Id))
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.FirstName + " " + u.LastName
                })
                .ToList();

            // Встановлюємо імена користувачів з роллю "teacher" у властивості SelectList
            ViewData["ConsultantID"] = new SelectList(teacherUserNames, "Value", "Text");

            // Отримати поточного користувача
            var currentUser = await _userManager.GetUserAsync(User);

            // Перевірити, чи користувач залогований
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // Отримати ідентифікатор користувача
            var currentUserId = currentUser.Id;

            // Завантажити роботи поточного користувача
            UserWorks = _context.Works.Where(w => w.AuthorID == currentUserId).ToList();
            GetTeacherNames();
            GetStudentsGrades();
            return Page();
        }
        public void GetStudentsGrades()
        {
            Grades = new List<string>();

            foreach (var work in UserWorks)
            {
                var workId = work.Id;
                var grade = _context.Grades.FirstOrDefault(g => g.WorkID == workId);
                if (grade != null)
                {
                    var gradeValue = $"{grade.GradeValue}";
                    Grades.Add(gradeValue);
                }
                else
                {
                    Grades.Add("No Grade");
                }
            }
        }
        public void GetTeacherNames()
        {
            TeachersNames = new List<string>();

            foreach (var work in UserWorks)
            {
                var teacherId = work.ConsultantID;
                var teacher = _context.Users.FirstOrDefault(u => u.Id == teacherId);
                if (teacher != null)
                {
                    // Додати ім'я вчителя до списку
                    var teacherName = $"{teacher.FirstName} {teacher.LastName}";
                    TeachersNames.Add(teacherName);
                }
                else
                {
                    // Якщо вчитель не знайдений, додати порожній рядок
                    TeachersNames.Add("");
                }
            }
        }
        public async Task<IActionResult> OnPostSaveChangesWorkAsync(string workId, string title, string topic, string status, string teacher)
        {
            await Console.Out.WriteLineAsync("IM WORKING");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Console.WriteLine("Data" + workId + title + topic + status + teacher);
            // Find the work by work ID
            WorkEntity work = await _context.Works.FindAsync(workId);

            if (work == null)
            {
                return NotFound();
            }

            // Update work properties
            work.Title = title;
            work.Topic = topic;
            work.Status = status;
            work.ConsultantID = teacher;

            _context.Works.Update(work); // Update the work in the context

            try
            {
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToPage(); // Redirect to the same page after successful update
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception if needed
                throw;
            }
        }
    }
}

