using System;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Account.Dtos.Request;
using Airelax.Application.Account.Dtos.Response;
using Airelax.Defines;
using Airelax.Domain.Members.Defines;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //註冊
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterInput input)
        {
            if (ModelState.IsValid)
            {
                var message = await _accountService.RegisterAccount(input);
                if (message != "此信箱已被註冊")
                {
                    SetJwt(message);
                    return Redirect(input.ReturnUrl);
                }
            }

            return View(input);
        }

        //登入
        [HttpGet]
        public IActionResult Login([FromQuery] string returnUrl = "/")
        {
            ViewBag.ReturnUrl = string.IsNullOrEmpty(returnUrl)? "/":returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginInput input)
        {
            if (!ModelState.IsValid) return View(input);
            var loginResult = _accountService.LoginAccount(input);
            switch (loginResult.Result)
            {
                case AccountStatus.Success:
                {
                    SetJwt(loginResult.Token);
                        //return Redirect(input.ReturnUrl);
                        //return RedirectToAction("Index", "Vue");
                        return Redirect("/");
                    }
                case AccountStatus.WrongPassword:
                    return View(input);
                case AccountStatus.Signup:
                {
                    var registerInput = new RegisterInput
                    {
                        Birthday = DateTime.Now,
                        Email = input.Account,
                        LoginType = LoginType.Email,
                        ReturnUrl = input.ReturnUrl
                    };
                    return View("Register", registerInput);
                }
                default:
                    return View(input);
            }
        }

        // google facebook line

        public IActionResult ThirdParty(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("DefaultResponse", "Account", new {returnUrl});
            return new ChallengeResult(provider, new AuthenticationProperties {RedirectUri = redirectUrl ?? "/"});
        }

        public async Task<IActionResult> DefaultResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value,
                    claim.ValueType,
                    claim.Properties
                });
            return Json(claims);
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete(Define.Authorization.JWT_COOKIE_KEY);
            await HttpContext.SignOutAsync();
            //return RedirectToAction("Index", "Vue");
            return Redirect("/");
        }

        private void SetJwt(string token)
        {
            Response.Cookies.Append(Defines.Define.Authorization.JWT_COOKIE_KEY,
                token, new CookieOptions() {SameSite = SameSiteMode.Strict});
        }
    }
}