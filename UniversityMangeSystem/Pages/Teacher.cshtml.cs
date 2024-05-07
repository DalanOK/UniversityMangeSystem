using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UniversityMangeSystem.Pages
{
    [Authorize(Roles = "teacher")]
    public class TeacherModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
