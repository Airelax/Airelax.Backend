using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Airelax.Application.Account.Dtos.Request;
using Airelax.Application.Account.Dtos.Response;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.Domain.RepositoryInterface;
using Airelax.Infrastructure.Helpers;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Airelax.Application.Account
{
    [DependencyInjection(typeof(IAccountService))]
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMemberRepository _memberRepository;

        public AccountService(IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            IMemberRepository memberRepository)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _memberRepository = memberRepository;
        }

        public async Task<Member> GetMember()
        {
            var memberId = GetAuthMemberId();
            if (memberId == null) return null;
            var member = await _memberRepository.GetAsync(x => x.Id == memberId);
            return member;
        }

        public string GetAuthMemberId()
        {
            var memberId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (memberId.IsNullOrEmpty()) throw ExceptionBuilder.Build(HttpStatusCode.Forbidden, "not log in");
            return memberId;
        }

        public async Task<string> RegisterAccount(RegisterInput input)
        {
            var member = await _memberRepository.GetMemberByAccountAsync(input.Email);

            var loginType = LoginType.Email;
            if (member != null) return "此信箱已被註冊";
            var name = input.LastName + input.FirstName;
            var password = CryptographyHelper.Hash(input.Password, out _);
            //尚未產出Id
            var newMember = new Member
            {
                Name = name,
                Birthday = input.Birthday,
                Email = input.Email,
                // todo default cover
                Cover = "https://www.zuckermanlaw.com/wp-content/uploads/whistleblowing/anonymous-sec-whistleblower.jpg"
            };

            //以產出Id
            var memberLogInfo = new MemberLoginInfo(newMember.Id)
            {
                Account = input.Email,
                Password = password,
                LoginType = loginType,
                Token = CreateToken(newMember)
            };
            newMember.MemberLoginInfo = memberLogInfo;
            await _memberRepository.CreateAsync(newMember);
            await _memberRepository.SaveChangesAsync();
            await SetCookieLogIn(newMember);
            return memberLogInfo.Token;
        }

        public LoginResult LoginAccount(LoginInput input)
        {
            var account = (input.Account);
            var mem = _memberRepository.GetMemberByAccountAsync(account).Result;
            var result = new LoginResult() {Token = string.Empty};

            if (mem != null)
            {
                var isPasswordPass = CryptographyHelper.VerifyHash(HttpUtility.HtmlEncode(input.Password), mem.MemberLoginInfo.Password);

                if (isPasswordPass)
                {
                    var token = CreateToken(mem);
                    mem.MemberLoginInfo.Token = token;
                    _memberRepository.UpdateAsync(mem).Wait();
                    SetCookieLogIn(mem).Wait();
                    result.Token = token;
                    result.Result = AccountStatus.Success;

                    return result;
                }

                result.Result = AccountStatus.WrongPassword;
                return result;
            }

            result.Result = AccountStatus.Signup;
            return result;
        }

        private string CreateToken(Member member)
        {
            var claims = GetClaims(member);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddYears(1), signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private static IEnumerable<Claim> GetClaims(Member member)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, member.Id),
                new(ClaimTypes.Name, member.Name),
                new(ClaimTypes.UserData, member.Cover ?? "")
            };
            return claims;
        }

        private async Task SetCookieLogIn(Member member)
        {
            var claims = GetClaims(member);
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await _httpContextAccessor.HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties()
            {
                IsPersistent = true
            });
        }
    }
}