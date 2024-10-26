﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Travel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Hour { get; set; }
        public int SchoolId { get; set; }
        public int Capacity { get; set; } = 20;
        public School? School { get; set; }
        public List<User> Passengers { get; set; } = new List<User>();

    }
}
