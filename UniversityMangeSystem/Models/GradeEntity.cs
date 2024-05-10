using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityMangeSystem.Models
{
    public class GradeEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int GradeValue { get; set; }
        public DateTime EvaluationDate { get; set; }

        public string WorkID { get; set; } 

        public WorkEntity? Work { get; set; }
    }
}
