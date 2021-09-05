using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using Airelax.Application.Account.Dtos.Request;
using Airelax.Application.Account.Dtos.Response;
using Airelax.Application.Helpers;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Airelax.Application.Account
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
            var member = _accountRepo.GetMemByEmail(HttpUtility.HtmlEncode(input.Email));

            var email = HttpUtility.HtmlEncode(input.Email);
            var loginType = LoginType.Email;
            if (member == null) //未被註冊的email
            {
                var name = HttpUtility.HtmlEncode(input.LastName) + HttpUtility.HtmlEncode(input.FirstName);
                var birthday = input.Birthday;
                var password = Cryptography.Hash(HttpUtility.HtmlEncode(input.Password), out var Salt);


                var mem = new Member
                {
                    Name = name,
                    Birthday = birthday,
                    Email = email,
                    // todo default cover
                    Cover = "acvavevasabhetscv"
                };

                //Member mem = _regService.memObj(input);


                //尚未產出Id
                _accountRepo.AddMem(mem);
                //以產出Id


                //string memId = _accountRepo.GetIdByEmail(email);

                var memberLogInfo = new MemberLoginInfo(mem.Id)
                {
                    Account = email,
                    Password = password,
                    LoginType = loginType,
                    Token = CreateToken(mem)
                };

                _accountRepo.AddMemInfo(memberLogInfo);
                _accountRepo.SaveChange();


                return "註冊成功!";
            }

            return "此信箱已被註冊";
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

                result.token = "";
                result.result = "wrongPassword";
                return result;
            }

            result.token = "";
            result.result = "signup";
            return result;
        }


        private string CreateToken(Member member)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, member.Id),
                new(ClaimTypes.Name, member.Name),
                new(ClaimTypes.UserData, member.Cover ?? "")
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}