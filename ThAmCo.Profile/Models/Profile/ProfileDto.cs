using System;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Profile.Models.Profile
{
    public class ProfileDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Forename { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
