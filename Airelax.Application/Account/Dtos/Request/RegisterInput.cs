using System;
using System.ComponentModel.DataAnnotations;
using Airelax.Domain.Members.Defines;

namespace Airelax.Application.Account.Dtos.Request
{
    public class RegisterInput
    {
        [Required] [Display(Name = "姓氏")] public string LastName { get; set; }

        [Required] [Display(Name = "名字")] public string FirstName { get; set; }

        public LoginType LoginType { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }


        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "出生日期")]
        public DateTime Birthday { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        //[StringLength(12,MinimumLength =8)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}