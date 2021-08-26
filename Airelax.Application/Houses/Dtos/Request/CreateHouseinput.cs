using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request
{
    public class CreateHouseInput
    {
        public Category Category { get; set; }
        public string MemberId { get; set; }
    }
}

