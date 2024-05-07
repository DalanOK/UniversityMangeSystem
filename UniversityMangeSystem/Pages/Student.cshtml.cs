using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UniversityMangeSystem.Pages
{
    [Authorize(Roles = "student")]
    public class StudentModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
