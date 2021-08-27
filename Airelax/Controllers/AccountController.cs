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
        public IActionResult Register(RegisterInput input)
        {
            if (ModelState.IsValid)
            {

                string message=_accountService.RegisterAccount(input);


                return Content(message);
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
        public IActionResult Login(LoginInput input)
        {

            if (ModelState.IsValid)
            {
                string result=_accountService.LoginAccount(input);
                if(result== "success")
                {
                    return Content("登入成功");
                }
                else if(result== "wrongPassword")
                {
                    return Content("密碼錯誤"); 
                }
                else if(result== "signup")
                {


                    RegisterInput login = new RegisterInput
                    {

                        Birthday = DateTime.Now,
                        Email = input.Account,

                        LoginType = LoginType.Email
                    };
                    return View("Register", login);
                }
                
                
                
            }

            return View(input);
        }
    }

}
