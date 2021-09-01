using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.ManageHouses.Request
{
    public class UploadHouseImagesInput
    {
        [Required] public IEnumerable<string> Images { get; set; }
    }
}