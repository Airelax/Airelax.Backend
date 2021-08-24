using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Airelax.Application.Account.Dtos.Request;
using Airelax.Application.Helpers;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.EntityFramework.DbContexts;

namespace Airelax.Services
{
    public class RegisterService
    {
        private readonly AirelaxContext _ctx;

        public RegisterService(AirelaxContext airelaxContext)
        {
            _ctx = airelaxContext;
        }
        public Member memObj(RegisterInput regVM)
        {

            string name = HttpUtility.HtmlEncode(regVM.LastName) + HttpUtility.HtmlEncode(regVM.FirstName);
            DateTime birthday = regVM.Birthday;
            string email = HttpUtility.HtmlEncode(regVM.Email);
           



            Member mem = new Member
            {
                Name = name,
                Birthday = birthday,
                Email = email
            };

            return mem;

        }

        public MemberLoginInfo memLoginInfoObj(RegisterInput regVM)
        {

            
            
            string email = HttpUtility.HtmlEncode(regVM.Email);
            string password = Cryptography.Hash(HttpUtility.HtmlEncode(regVM.Password), out string Salt);
            LoginType logintype = LoginType.Email;

            Member memcomfirm = _ctx.Members.SingleOrDefault((m) => m.Email == regVM.Email);
            string memId = memcomfirm.Id;
            MemberLoginInfo meminfo = new MemberLoginInfo(memId)
            {
                Account = email,
                Password = password,
                LoginType = logintype
            };

            return meminfo;
        }




    }
}
