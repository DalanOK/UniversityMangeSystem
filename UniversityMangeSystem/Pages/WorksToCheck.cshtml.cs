using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using UniversityMangeSystem.Models;
using UniversityMangeSystem.Services;

namespace UniversityMangeSystem.Pages
{
    public class WorksToCheckModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WorksToCheckModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<WorkEntity> UserWorks { get; set; }
        public List<string> StudentNames { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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
            UserWorks = _context.Works
            .Where(w => w.ConsultantID == currentUserId && !_context.Grades.Any(g => g.WorkID == w.Id))
            .ToList();
            GetStudentsNames();
            return Page();
        }
        public void GetStudentsNames()
        {
            StudentNames = new List<string>();

            foreach (var work in UserWorks)
            {
                var authorId = work.AuthorID;
                var author = _context.Users.FirstOrDefault(u => u.Id == authorId);
                if (author != null)
                {
                    // Додати ім'я вчителя до списку
                    var teacherName = $"{author.FirstName} {author.LastName}";
                    StudentNames.Add(teacherName);
                }
                else
                {
                    // Якщо вчитель не знайдений, додати порожній рядок
                    StudentNames.Add("");
                }
            }
        }
        public async Task<IActionResult> OnPostGradeWorkAsync(string workId, int workGrade)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var work = _context.Works.FirstOrDefault(w => w.Id == workId);

            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            work.Status = "Cheсked";
            // Створення нового об'єкту Grade
            var grade = new GradeEntity
            {
                GradeValue = workGrade,
                EvaluationDate = DateTime.Now,
                WorkID = workId
            };

            // Додавання оцінки до контексту бази даних
            _context.Grades.Add(grade);
            _context.Works.Update(work);

            // Збереження змін в базі даних
            await _context.SaveChangesAsync();

            // Повернення результату
            return RedirectToPage("/WorksToCheck"); // або будь-який інший результат, який ви хочете повернути
        }
    }
}
