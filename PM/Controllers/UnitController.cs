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
    public class UnitController : Controller
    {
        private readonly IUnitService _unitController;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="LogLoginService"></param>
        /// <returns></returns>
        public UnitController(IUnitService unitService)
        {
            this._unitController = unitService;
        }
        public IActionResult AddEdit(int Id)
        {
            var model = new ProductUnit();
            if (Id > 0)
            {
                model = _unitController.Get(Id);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEdit(ProductUnit model)
        {
            if (ModelState.IsValid)
            {
                var isValid = false;
                var msg = "";
                if (model.UnitId > 0)
                {
                    var cate = _unitController.Get(model.UnitId);
                    if(cate != null)
                    {
                        cate.UnitName = model.UnitName;
                        cate.Description = model.Description;
                        isValid = _unitController.Update(cate);
                        msg = "Đã cập nhật ngành hàng thành công!";
                    }
                }
                else
                {
                    isValid = _unitController.Create(model);
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
                return View(model);
            }
            return View(model);
        }
        public IActionResult Listing()
        {
            return View(_unitController.GetAll());
        }
        public IActionResult Delete(int Id)
        {
            var model = new ProductUnit();
            if (Id > 0)
            {
                model = _unitController.Get(Id);
                if(model != null)
                {
                    model.IsDelete = true;
                    _unitController.Update(model);
                }
            }
            return RedirectToAction("Listing");
        }
    }
}
