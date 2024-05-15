using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMangeSystem.Models;
using UniversityMangeSystem.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UniversityMangeSystem.Pages
{
    public class ChatHistoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatHistoryModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public string WorkId { get; set; }

        public List<Message> Messages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // Load the chat history for the given work
            Messages = await _context.Messages
                .Where(m => m.WorkID == WorkId)
                .OrderBy(m => m.DateSent)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostNewMessageAsync(string workId, string NewMessage)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            WorkEntity work = await _context.Works.FindAsync(workId);
            string reciver = GetReciverId(currentUser.Id, work);

            if (string.IsNullOrWhiteSpace(NewMessage))
            {
                return RedirectToPage();
            }

            var message = new Message
            {
                Data = NewMessage,
                SenderID = currentUser.Id, 
                Status = "new",
                ReceiverID = reciver, 
                WorkID = workId, 
                DateSent = DateTime.Now
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToPage(new {workId = workId});
        }
        private string GetReciverId(string currentUser, WorkEntity work)
        {
            if(work.ConsultantID == currentUser)
            {
                return work.AuthorID;
            }
            else
            {
                return work.ConsultantID;
            }
        }
    }
}

