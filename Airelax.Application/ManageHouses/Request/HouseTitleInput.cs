using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.ManageHouses.Request
{
    public class HouseTitleInput
    {
        [MaxLength(50)] public string Title { get; set; }
    }
}