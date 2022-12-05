using System.ComponentModel.DataAnnotations;

namespace PasswordAPI.Models
{
    public class PasswordRequest
    {
        [Required(ErrorMessage = "Tag is required")]
        public string Tag { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Value is required")]
        public string Value { get; set; } = string.Empty;

        [Required(ErrorMessage = "Master Key is required")]
        public string MasterKey { get; set; } = string.Empty;

    }
}
