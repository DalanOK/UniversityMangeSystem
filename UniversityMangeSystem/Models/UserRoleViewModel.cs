namespace UniversityMangeSystem.Models
{
    public class UserRoleViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; }
        public string UserId { get; internal set; }
    }
}
