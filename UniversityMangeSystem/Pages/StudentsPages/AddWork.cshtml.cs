using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityMangeSystem.Models;
using UniversityMangeSystem.Services;

namespace UniversityMangeSystem.Pages
{
    public class AddWorkModel : PageModel
    {
        private readonly UniversityMangeSystem.Services.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddWorkModel(UniversityMangeSystem.Services.ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            //geting current UserId
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            UserId = Convert.ToString(currentUser.Id);
            
            WorkId = GenerateNewId();

            var teacherUserIds = _context.UserRoles
    .Where(ur => ur.RoleId == "ed2cd96f-85c3-46aa-af54-bb3b1a8e96b0")
    .Select(ur => ur.UserId)
    .ToList();

            // Отримуємо імена користувачів з роллю "teacher"
            var teacherUserNames = _context.Users
                .Where(u => teacherUserIds.Contains(u.Id))
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                })
                .ToList();

            // Встановлюємо імена користувачів з роллю "teacher" у властивості SelectList
            ViewData["ConsultantID"] = new SelectList(teacherUserNames, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public WorkEntity WorkEntity { get; set; } = new WorkEntity(); 

        public string WorkId;
        public string UserId;

        private string GenerateNewId()
        {
         var maxId = _context.Works
            .Select(w => w.Id)
            .ToList()
            .Select(id => int.TryParse(id, out var num) ? num : 0) 
            .DefaultIfEmpty(0) 
            .Max(); 
   
         return (maxId + 1).ToString();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Works == null || WorkEntity == null)
            {
                return Page();
            }

            _context.Works.Add(WorkEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("");
        }
    }
}
