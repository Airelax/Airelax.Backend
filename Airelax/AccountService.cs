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
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Airelax.Application.Account.Dtos.Response;

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
                    Email = email,
                    Cover="acvavevasabhetscv"
                };

                //Member mem = _regService.memObj(input);



                //尚未產出Id
                _accountRepo.addMem(mem);
                _accountRepo.SaveChange();
                //以產出Id

                


                string memId = _accountRepo.GetIdByEmail(email);

                MemberLoginInfo meminfo = new MemberLoginInfo(memId)
                {
                    Account = email,
                    Password = password,
                    LoginType = logintype,
                    Token=CreateToken(mem)
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
        
        public LoginResult LoginAccount(LoginInput input)
        {
            string account = HttpUtility.HtmlEncode(input.Account);
            MemberLoginInfo member = _accountRepo.GetAccountByAccount(account);
            LoginResult result = new LoginResult();
           
            if (member != null)
            {
                bool password = Cryptography.VerifyHash(HttpUtility.HtmlEncode(input.Password), member.Password);

                if (password == true)
                {
                    var token = CreateTokenByLoginVM(input);
                    _accountRepo.UpdateToken(member.Id,token);

                    result.token = token;
                    result.result = "success";
                   
                    return result;
                }
                else
                {
                    result.token = "";
                    result.result = "wrongPassword";
                    return result;
                }
            }
            else
            {
                result.token = "";
                result.result = "signup";
                return result;
            }
        }


        private string CreateToken(Member mem)
        {
            var memId = _accountRepo.GetIdByEmail(mem.Email);
            var memName = _accountRepo.GetNameByEmail(mem.Email);
            var memCover = _accountRepo.GetCoverByEmail(mem.Email);

            var claims = new List<Claim>()
            {
                    new Claim(ClaimTypes.NameIdentifier, memId.ToString()),
                    new Claim(ClaimTypes.Name, memName),
                    new Claim(ClaimTypes.UserData,memCover)
            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MagicMagicMagicMagic"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }



        private string CreateTokenByLoginVM(LoginInput input)
        {
            var mem = _accountRepo.GetMemByAccount(input.Account);
            var memId = _accountRepo.GetIdByEmail(mem.Email);
            var memName = _accountRepo.GetNameByEmail(mem.Email);
            var memCover = _accountRepo.GetCoverByEmail(mem.Email);

            var claims = new List<Claim>()
            {
                    new Claim(ClaimTypes.NameIdentifier, memId.ToString()),
                    new Claim(ClaimTypes.Name, memName),
                    new Claim(ClaimTypes.UserData,memCover)
            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MagicMagicMagicMagic"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}
