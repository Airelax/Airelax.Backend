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
using Microsoft.Extensions.Configuration;

namespace Airelax
{
    [DependencyInjection(typeof(IAccountService))]
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepo, IConfiguration configuration)
        {
            _accountRepo = accountRepo;
            _configuration = configuration;
        }


        public string RegisterAccount(RegisterInput input)
        {
            Member member = _accountRepo.GetMemByEmail(HttpUtility.HtmlEncode(input.Email));

            if (member == null) //未被註冊的email
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
                    Cover = "acvavevasabhetscv"
                };

                //Member mem = _regService.memObj(input);


                //尚未產出Id
                _accountRepo.AddMem(mem);
                //以產出Id


                //string memId = _accountRepo.GetIdByEmail(email);

                MemberLoginInfo meminfo = new MemberLoginInfo(mem.Id)
                {
                    Account = email,
                    Password = password,
                    LoginType = logintype,
                    Token = CreateToken(mem)
                };

                _accountRepo.AddMemInfo(meminfo);
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
            var account = HttpUtility.HtmlEncode(input.Account);
            var memberInfo = _accountRepo.GetMemberInfoByAccount(account);
            var mem = _accountRepo.GetMemByAccount(account);
            var result = new LoginResult();

            if (mem != null)
            {
                var isPasswordPass = Cryptography.VerifyHash(HttpUtility.HtmlEncode(input.Password), memberInfo.Password);

                if (isPasswordPass)
                {
                    var token = CreateToken(mem);
                    _accountRepo.UpdateToken(memberInfo.Id, token);

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


        private string CreateToken(Member member)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
                new Claim(ClaimTypes.Name, member.Name),
                new Claim(ClaimTypes.UserData, member.Cover ?? "")
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}