using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataService.Services;
using DataService.Interfaces;
using PM.lib;
using Microsoft.AspNetCore.Authorization;
using PM.Models;
namespace PM.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="LogLoginService"></param>
        /// <returns></returns>
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IActionResult AddEdit(int cateId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEdit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var isValid = _categoryService.Create(model);
                if (isValid)
                {
                    ViewBag.Msg = "Đã tạo ngành hàng thành công!";
                    ModelState.Remove("InvalidAuth");
                }
                else
                {
                    ModelState.AddModelError("InvalidAuth", "Tên đăng nhập hoặc mật khẩu không chính xác");
                }
                return View(model);
            }
            return View(model);
        }
        public IActionResult Listing()
        {
            return View(_categoryService.GetAll());
        }
    }
}
