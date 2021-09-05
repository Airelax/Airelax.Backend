using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.Houses.Dtos.Request
{
    public class UpdateHouseTitleInput
    {
        [MaxLength(50)] public string Title { get; set; }
    }
}