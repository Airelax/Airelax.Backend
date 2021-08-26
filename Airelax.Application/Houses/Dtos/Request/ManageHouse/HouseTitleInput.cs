using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request.ManageHouse
{
    public class HouseTitleInput
    {
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
