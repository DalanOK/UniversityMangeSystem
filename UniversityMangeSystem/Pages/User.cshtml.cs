using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMangeSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityMangeSystem.Services;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Net;

namespace UniversityMangeSystem.Pages
{
    [Authorize(Roles = "admin")]
    public class UserModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public List<UserRoleViewModel> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }

        public UserModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync()
        {
            Roles = await _roleManager.Roles.ToListAsync();

            var users = await _userManager.Users.ToListAsync();

            Users = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault();

                Users.Add(new UserRoleViewModel
                {
                    UserId = user.Id,  
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    CreatedAt = user.CreatedAt,
                    Role = roleName
                });
            }
        }
        public async Task<IActionResult> OnPostSaveChangesAsync(string userId, string firstName, string lastName, string email, string phoneNumber, string address, string role)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Find the user by user ID
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            // Update user properties
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.PhoneNumber = phoneNumber;
            user.Address = address;

            // Update user roles (optional)
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles.ToArray());
            await _userManager.AddToRoleAsync(user, role);

            // Save changes to the database
            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return RedirectToPage();
            }
            else
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
        }
        public async Task<IActionResult> OnPostDeleteUserAsync() 
        {
            var user = await _userManager.FindByIdAsync("cb6e1de5-a4f7-44b1-aec4-b79cdedf2ae9");
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToPage(); 
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
        }
    }
}
