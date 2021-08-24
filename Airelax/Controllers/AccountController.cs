using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Account.Dtos.Request;
using Airelax.EntityFramework.DbContexts;
using Airelax.Domain.Members;
using Airelax.Application.Helpers;
using System.Web;
using Airelax.Domain.Members.Defines;
using Airelax.Services;

namespace Airelax.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly AirelaxContext _airelaxContext;
        private readonly RegisterService _regService;

        public AccountController(AirelaxContext airelaxContext/*,RegisterService regService*/)
        {
            _airelaxContext = airelaxContext;
            //_regService = regService;
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
                var memberEmail = _airelaxContext.MemberLoginInfos.SingleOrDefault((m) => m.Account == input.Email);
                
                if (memberEmail == null)
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
                    using(var tran = _airelaxContext.Database.BeginTransaction())
                    {
                        try
                        {
                            _airelaxContext.Members.Add(mem);
                             _airelaxContext.SaveChanges();

                            tran.Commit();
                        }
                        catch(Exception ex)
                        {
                            tran.Rollback();
                        }
                    }
                    //以產出Id

                    Member memcomfirm = _airelaxContext.Members.SingleOrDefault((m) => m.Email == input.Email);
                    string memId = memcomfirm.Id;
                    MemberLoginInfo meminfo = new MemberLoginInfo(memId)
                    {
                        Account = email,
                        Password = password,
                        LoginType = logintype
                    };

                    //MemberLoginInfo meminfo = _regService.memLoginInfoObj(input);


                    using(var tran = _airelaxContext.Database.BeginTransaction())
                    {
                        try
                        {
                            _airelaxContext.MemberLoginInfos.Add(meminfo);
                           _airelaxContext.SaveChanges();

                            tran.Commit();
                        }
                        catch(Exception ex)
                        {
                            tran.Rollback();
                        }
                    }
                    

                    return Content("註冊成功!");

                }
                else
                {
                    return Content("此信箱已被註冊");
                }

            }
            else
            {
                return View(input);
            }
            
        }



        //登入
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInput input)
        {

            if (ModelState.IsValid)
            {
                string account = HttpUtility.HtmlEncode(input.Account);
                MemberLoginInfo member = _airelaxContext.MemberLoginInfos.SingleOrDefault((m) => m.Account == account);
                if (member != null)
                {
                    bool password = Cryptography.VerifyHash(HttpUtility.HtmlEncode(input.Password) ,member.Password);


                    if (password==true)
                    {
                        return Content("登入成功");
                    }
                    else
                    {
                        return Content("密碼錯誤");
                    }
                }
                else
                {
                    RegisterInput login = new RegisterInput
                    {
                        FirstName="",
                        LastName ="",
                        Birthday=DateTime.Now,
                        Email=input.Account,
                        Password="",
                        LoginType = LoginType.Email
                };
                    return View("Register", login);
                }
            }
            return View(input);
        }
    }

}
