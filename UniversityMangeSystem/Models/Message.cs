using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityMangeSystem.Models
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public string WorkID { get; set; }
        public DateTime DateSent { get; set; }

        // Навігаційна властивість до роботи
        [ForeignKey("WorkID")]
        public virtual WorkEntity Work { get; set; }

        // Навігаційна властивість до відправника повідомлення (користувача)
        [ForeignKey("SenderID")]
        public virtual ApplicationUser Sender { get; set; }

        // Навігаційна властивість до отримувача повідомлення (користувача)
        [ForeignKey("ReceiverID")]
        public virtual ApplicationUser Receiver { get; set; }
    }
}
