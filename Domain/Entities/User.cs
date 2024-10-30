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
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? FullName {  get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? DNI { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public District? District { get; set; }
        [Required]
        public Role? Role { get; set; }


    }
}
