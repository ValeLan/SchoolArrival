﻿namespace Application.Models.Dtos
{
    public class TravelDto
    {
        public int Id { get; set; }
        public string? Hour { get; set; }
        public SchoolDto? School { get; set; }
        public List<UserDto> Passengers { get; set; } = new List<UserDto>();
    }
}
