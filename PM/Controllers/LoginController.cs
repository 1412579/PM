﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataService.Interfaces;
using PM.lib;
using PM.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
namespace PM.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="LogLoginService"></param>
        /// <returns></returns>
        public LoginController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        public IActionResult Index(string requestPath)
        {
            ViewBag.RequestPath = requestPath ?? "/";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = IsAuthenticated(model.Username, model.Password);
                if (User != null)
                {
                    await LoginAsync(User);
                    if (IsUrlValid(model.RequestPath))
                    {
                        return Redirect(model.RequestPath);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("InvalidAuth", "Tên đăng nhập hoặc mật khẩu không chính xác");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout(string requestPath)
        {
            await HttpContext.SignOutAsync(
                    scheme: CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        private Users IsAuthenticated(string Username, string Password)
        {
            return _accountService.Login(Username, Password);
        }
        public IActionResult Access()
        {
            return View();
        }

        private static bool IsUrlValid(string returnUrl)
        {
            return !string.IsNullOrWhiteSpace(returnUrl)
                   && Uri.IsWellFormedUriString(returnUrl, UriKind.Relative);
        }

        private async Task LoginAsync(Users model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, model.UserId.ToString()),
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(ClaimTypes.UserData, model.FullName),
                new Claim(ClaimTypes.Role, "Admin"),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }

    }
}