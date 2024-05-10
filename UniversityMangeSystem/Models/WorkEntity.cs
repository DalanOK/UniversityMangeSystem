using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityMangeSystem.Models
{
    public class WorkEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Status { get; set; }

        public string AuthorID { get; set; }
        public string ConsultantID { get; set; } 

        public ApplicationUser? Author { get; set; }
        public ApplicationUser? Consultant { get; set; }
    }
}
