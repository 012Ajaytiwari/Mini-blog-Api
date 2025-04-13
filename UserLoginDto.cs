// DTOusing System.ComponentModel.DataAnnotations;

namespace MiniBlogAPI.ViewModels
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
 for user login
