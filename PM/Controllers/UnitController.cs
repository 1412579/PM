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
        private readonly IUnitService _unitService;
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
            this._unitService = unitService;
        }
        public IActionResult AddEdit(int modelId)
        {
            var model = new ProductUnit();
            if (modelId > 0)
            {
                model = _unitService.Get(modelId);
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
                    var cate = _unitService.Get(model.UnitId);
                    if(cate != null)
                    {
                        cate.UnitName = model.UnitName;
                        cate.Description = model.Description;
                        isValid = _unitService.Update(cate);
                        msg = "Đã cập nhật đơn vị thành công!";
                    }
                }
                else
                {
                    isValid = _unitService.Create(model);
                    msg = "Đã tạo đơn vị thành công!";
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
                model.UnitId = 0;
                return View(model);
            }
            return View(model);
        }
        public IActionResult Listing()
        {
            return View(_unitService.GetAll());
        }
        public IActionResult Delete(int Id)
        {
            var model = new ProductUnit();
            if (Id > 0)
            {
                model = _unitService.Get(Id);
                if(model != null)
                {
                    model.IsDelete = true;
                    _unitService.Update(model);
                }
            }
            return RedirectToAction("Listing");
        }
    }
}
