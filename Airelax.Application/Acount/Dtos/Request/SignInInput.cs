using Airelax.Domain.Members.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Acount.Dtos.Request
{
    public class SignIninput
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public LoginType LoginType { get; set; }
    }
}
