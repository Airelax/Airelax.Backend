using Airelax.Application.Account.Dtos.Request;
using Airelax.Application.Helpers;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax
{
    [DependencyInjection(typeof(IAccountService))]
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        public AccountService(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }



        public string RegisterAccount(RegisterInput input)
        {
            Member memberEmail = _accountRepo.GetEmailByEmail(HttpUtility.HtmlEncode(input.Email));

            if (memberEmail == null)//未被註冊的email
            {
                string name = HttpUtility.HtmlEncode(input.LastName) + HttpUtility.HtmlEncode(input.FirstName);
                DateTime birthday = input.Birthday;
                string email = HttpUtility.HtmlEncode(input.Email);
                string password = Cryptography.Hash(HttpUtility.HtmlEncode(input.Password), out string Salt);
                LoginType logintype = LoginType.Email;


                Member mem = new Member()
                {
                    Name = name,
                    Birthday = birthday,
                    Email = email
                };

                //Member mem = _regService.memObj(input);



                //尚未產出Id
                _accountRepo.addMem(mem);
                _accountRepo.SaveChange();
                //以產出Id

                _accountRepo.SaveChange();


                string memId = _accountRepo.GetIdByEmail(email);

                MemberLoginInfo meminfo = new MemberLoginInfo(memId)
                {
                    Account = email,
                    Password = password,
                    LoginType = logintype
                };

                _accountRepo.addMemInfo(meminfo);
                _accountRepo.SaveChange();


                return ("註冊成功!");

            }
            else
            {
                return ("此信箱已被註冊");
            }
        }



        public string LoginAccount(LoginInput input)
        {
            string account = HttpUtility.HtmlEncode(input.Account);
            MemberLoginInfo member = _accountRepo.GetAccountByAccount(account);

            if (member != null)
            {
                bool password = Cryptography.VerifyHash(HttpUtility.HtmlEncode(input.Password), member.Password);


                if (password == true)
                {
                    return "success";
                }
                else
                {
                    return "wrongPassword";
                }
            }
            else
            {
                
                return "signup";
            }
        }
    }
}
