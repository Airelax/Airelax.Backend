using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.MemberInfo.Request
{
    public class EditPhotoInput
    {
        [Required]
        public string PhotoUrl { get; set; }
    }
}