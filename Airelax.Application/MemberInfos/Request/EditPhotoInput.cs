using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.MemberInfos.Request
{
    public class EditPhotoInput
    {
        [Required] public string PhotoUrl { get; set; }
    }
}