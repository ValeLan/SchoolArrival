using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class SchoolSaveRequest
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? SchoolAdress { get; set; }
    }
}
