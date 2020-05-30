using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.ViewModels
{
    public class AuthenticateViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
