using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain.Models;

namespace Domain.Entities
{
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FullName {  get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DNI { get; set; }
        public bool IsActive { get; set; }
        public District? District { get; set; }
        public Role? Role { get; set; }
    }
}
