using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AkademiPlusMicroServiceProject.IdentityServer.DTOs
{
    public class SignUpDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
