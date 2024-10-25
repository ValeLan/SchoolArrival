using Domain.Enums;

namespace Application.Models.Requests
{
    public class UserRequest
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
