using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.Houses.Dtos.Request
{
    public class UpdateHouseDescriptionInput
    {
        [MaxLength(500)] public string Description { get; set; }
    }
}