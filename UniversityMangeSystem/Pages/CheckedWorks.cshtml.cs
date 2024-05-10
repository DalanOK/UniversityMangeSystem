using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMangeSystem.Models;
using UniversityMangeSystem.Services;

namespace UniversityMangeSystem.Pages
{
    public class CheckedWorksModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckedWorksModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<WorkEntity> UserWorks { get; set; }
        public List<string> StudentNames { get; set; }
        public List<string> Grades {  get; set; }

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
            .Where(w => w.ConsultantID == currentUserId && _context.Grades.Any(g => g.WorkID == w.Id))
            .ToList();
            GetStudentsNames();
            GetStudentsGrades();
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
                    Grades.Add("");
                }
            }
        }
        public async Task<IActionResult> OnPostChangeGradeWorkAsync(string workId, int workGrade)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            GradeEntity grade = _context.Grades.FirstOrDefault(g => g.WorkID == workId);
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // ��������� ������ ��'���� Grade
            grade.GradeValue = workGrade; 
            

            // ��������� ������ �� ��������� ���� �����
            _context.Grades.Update(grade);

            // ���������� ��� � ��� �����
            await _context.SaveChangesAsync();

            return RedirectToPage(""); 
        }
    }
}
