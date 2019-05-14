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
        public IActionResult AddEdit(int modelId)
        {
            var model = new ProductCategory();
            if (modelId > 0)
            {
                model = _categoryService.Get(modelId);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEdit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var isValid = false;
                var msg = "";
                if (model.CategoryId > 0)
                {
                    var cate = _categoryService.Get(model.CategoryId);
                    if(cate != null)
                    {
                        cate.CategoryName = model.CategoryName;
                        cate.Description = model.Description;
                        isValid = _categoryService.Update(cate);
                        msg = "Đã cập nhật ngành hàng thành công!";
                    }
                }
                else
                {
                    isValid = _categoryService.Create(model);
                    msg = "Đã tạo ngành hàng thành công!";
                }

                if (isValid)
                {
                    ViewBag.Msg = msg;
                    ModelState.Remove("InvalidAuth");
                }
                else
                {
                    ModelState.AddModelError("InvalidAuth", "Đã có lỗi xảy ra, liên hệ IT.");
                }
                model.CategoryId = 0;
                return View(model);
            }
            return View(model);
        }
        public IActionResult Listing()
        {
            return View(_categoryService.GetAll());
        }
        public IActionResult Delete(int cateId)
        {
            var model = new ProductCategory();
            if (cateId > 0)
            {
                model = _categoryService.Get(cateId);
                if(model != null)
                {
                    model.IsDelete = true;
                    _categoryService.Update(model);
                }
            }
            return RedirectToAction("Listing");
        }
    }
}
