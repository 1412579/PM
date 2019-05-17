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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PM.Controllers
{
    [AllowAnonymous]
    public class ImportController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImportService _importService;
        private readonly IUnitService _unitService;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="LogLoginService"></param>
        /// <returns></returns>
        public ImportController(IProductService productService, IImportService importService, IUnitService unitService)
        {
            this._productService = productService;
            this._importService = importService;
            this._unitService = unitService;
        }
        public IActionResult AddEdit(int productId, int importId)
        {
            if (productId <= 0)
                return RedirectToAction("Listing", "Product");
            if (productId > 0)
            {
                var pro = _productService.GetFullProductById(productId);
                if (pro != null)
                {
                    var model = new ProductImport();
                        model.ProductId = productId;
                    ViewBag.Product = pro;
                    if (importId > 0)
                    {
                        model = _importService.Get(importId);
                    }
                    else
                    {
                        model.ImportDate = DateTime.Now;
                    }
                    return View(model);
                }
            }
            return RedirectToAction("Listing", "Product");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEdit(ProductImport model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Product = _productService.GetFullProductById(model.ProductId);
                var isValid = false;
                var msg = "";
                var IsEdit = model.ImportId > 0;
                if (IsEdit)
                {
                    var pro = _importService.Get(model.ImportId);
                    if (pro != null)
                    {
                        pro.ImportFrom = model.ImportFrom;
                        pro.Price = model.Price;
                        pro.Quantity = model.Quantity;
                        pro.ImportDate = DateTime.Now;
                        pro.Description = model.Description;
                        isValid = _importService.Update(pro);
                        msg = "Đã cập nhật đơn nhập thành công!";
                    }
                }
                else
                {
                    isValid = _importService.Create(model);
                    msg = "Đã tạo đơn nhập thành công!";
                }

                if (isValid)
                {
                    ViewBag.Msg = msg;
                    ModelState.Remove("InvalidAuth");
                    if(!IsEdit)
                        model = new ProductImport();
                }
                else
                {
                    ModelState.AddModelError("InvalidAuth", "Đã có lỗi xảy ra, liên hệ IT.");
                }
                
                return View(model);
            }
            return View(model);
        }
        //public IActionResult Listing()
        //{
        //    return View();
        //}
        //public IActionResult Delete(int Id)
        //{
        //    var model = new Products();
        //    if (Id > 0)
        //    {
        //        model = _productService.Get(Id);
        //        if (model != null)
        //        {
        //            model.IsDelete = true;
        //            _productService.Update(model);
        //        }
        //    }
        //    return RedirectToAction("Listing");
        //}

    }
}
