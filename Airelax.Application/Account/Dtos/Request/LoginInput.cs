using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.Account.Dtos.Request
{
    public class LoginInput
    {
        [Required] [EmailAddress] public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}