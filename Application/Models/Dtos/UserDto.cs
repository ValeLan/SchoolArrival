namespace Application.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DNI { get; set; }
        public string? District { get; set; }
        public string? Role { get; set; }
    }
}
