using BusHandler.Data;
using System.ComponentModel.DataAnnotations;

namespace ApiForAngular.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        public List<Children>? Children { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}
