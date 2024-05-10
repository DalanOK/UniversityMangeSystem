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
            // �������� ��������� �����������
            var currentUser = await _userManager.GetUserAsync(User);

            // ���������, �� ���������� �����������
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // �������� ������������� �����������
            var currentUserId = currentUser.Id;

            // ����������� ������ ��������� �����������
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
                    // ������ ��'� ������� �� ������
                    var teacherName = $"{author.FirstName} {author.LastName}";
                    StudentNames.Add(teacherName);
                }
                else
                {
                    // ���� ������� �� ���������, ������ ������� �����
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
            work.Status = "Che�ked";
            // ��������� ������ ��'���� Grade
            var grade = new GradeEntity
            {
                GradeValue = workGrade,
                EvaluationDate = DateTime.Now,
                WorkID = workId
            };

            // ��������� ������ �� ��������� ���� �����
            _context.Grades.Add(grade);
            _context.Works.Update(work);

            // ���������� ��� � ��� �����
            await _context.SaveChangesAsync();

            // ���������� ����������
            return RedirectToPage("/WorksToCheck"); // ��� ����-���� ����� ���������, ���� �� ������ ���������
        }
    }
}
