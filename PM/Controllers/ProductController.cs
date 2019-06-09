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
using Newtonsoft.Json;
namespace PM.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IUnitService _unitService;
        private readonly IImportService _importService;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="LogLoginService"></param>
        /// <returns></returns>
        public ProductController(IProductService productService, ICategoryService categoryService, IUnitService unitService, IImportService importService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._unitService = unitService;
            this._importService = importService;
        }
        public IActionResult AddEdit(int modelId)
        {
            var model = new Products();
            if (modelId > 0)
            {
                model = _productService.Get(modelId);
                if (model != null)
                    ViewBag.ListImport = _importService.GetAllByProductId(modelId);
            }

            var ListCate = new List<SelectListItem>();
            var ListUnit = new List<SelectListItem>();
            BuildCatesAndUnits(model, ref ListCate,ref ListUnit);
            ViewBag.ListCate = ListCate.ToArray();
            ViewBag.ListUnit = ListUnit.ToArray();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEdit(Products model)
        {
            if (ModelState.IsValid)
            {
                var isValid = false;
                var msg = "";
                var ListCate = new List<SelectListItem>();
                var ListUnit = new List<SelectListItem>();
                BuildCatesAndUnits(model, ref ListCate, ref ListUnit);
                ViewBag.ListCate = ListCate.ToArray();
                ViewBag.ListUnit = ListUnit.ToArray();
                if (IsExistProductCode(model))
                {
                    ModelState.AddModelError("InvalidAuth", "Mã sản phẩm nhập đã tồn tại!");
                    return View(model);
                }
                var IsEdit = model.ProductId > 0;
                if (IsEdit)
                {
                    var pro = _productService.Get(model.ProductId);
                    if (pro != null)
                    {
                        pro.ProductName = model.ProductName;
                        pro.CategoryId = model.CategoryId;
                        pro.UnitId = model.UnitId;
                        pro.ProductCode = model.ProductCode;
                        pro.Price = model.Price;
                        pro.SalePrice = model.SalePrice;
                        pro.DetailContent = model.DetailContent;
                        isValid = _productService.Update(pro);
                        msg = "Đã cập nhật sản phẩm thành công!";
                    }
                }
                else
                {
                    isValid = _productService.Create(model);
                    msg = "Đã tạo sản phẩm thành công!";
                }

                if (isValid)
                {
                    ViewBag.Msg = msg;
                    ModelState.Remove("InvalidAuth");
                    if(!IsEdit)
                    model = new Products();
                }
                else
                {
                    ModelState.AddModelError("InvalidAuth", "Đã có lỗi xảy ra, liên hệ IT.");
                }
                //model.ProductId = 0;
                
                return View(model);
            }
            return View(model);
        }
        public IActionResult Listing()
        {
            var model = _productService.BuildProductsListing();
            return View(model);
        }
        public IActionResult Delete(int Id)
        {
            var model = new Products();
            if (Id > 0)
            {
                model = _productService.Get(Id);
                if (model != null)
                {
                    model.IsDelete = true;
                    _productService.Update(model);
                }
            }
            return RedirectToAction("Listing");
        }

        //private List<ProductView> BuildProductsListing()
        //{
        //    var rsl = new List<ProductView>();
        //    var products = _productService.GetAll();
        //    if(products != null && products.Any())
        //    {
        //        var cates = _categoryService.GetAll();
        //        var units = _unitService.GetAll();
        //        foreach(var item in products)
        //        {
        //            var model = new ProductView();
        //            model.Product = item;
        //            model.Category = cates.FirstOrDefault(x=>x.CategoryId == item.CategoryId) ?? null;
        //            model.Unit = units.FirstOrDefault(x => x.UnitId == item.UnitId) ?? null;
        //            rsl.Add(model);
        //        }
        //    }
        //    return rsl;
        //}

        private bool IsExistProductCode(Products model)
        {
            var rsl = _productService.GetByCode(model.ProductCode);
            return rsl != null && rsl.ProductId != model.ProductId;
        }

        private void BuildCatesAndUnits(Products model,ref List<SelectListItem> ListCate, ref List<SelectListItem> ListUnit)
        {
            var Cates = _categoryService.GetAll();
            var Units = _unitService.GetAll();
            if (Cates != null && Cates.Any())
                ListCate = Cates.Select(x => new SelectListItem()
                {
                    Selected = model != null && model.CategoryId == x.CategoryId ? true : false,
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            if (Units != null && Units.Any())
                ListUnit = Units.Select(x => new SelectListItem()
                {
                    Selected = model != null && model.UnitId == x.UnitId ? true : false,
                    Text = x.UnitName,
                    Value = x.UnitId.ToString()
                }).ToList();

            ListCate.Insert(0, new SelectListItem()
            {
                Selected = model == null,
                Text = "Chọn sản phẩm",
                Value = "-1"
            });

            ListUnit.Insert(0, new SelectListItem()
            {
                Selected = model == null,
                Text = "Chọn đơn vị",
                Value = "-1"
            });

        }


        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCustomer(string phone)
        {
            var model = _productService.GetContactsByPhone(phone);
            if(model != null)
                return Json(new
                {
                    Status = 1,
                    Data = JsonConvert.SerializeObject(model),
                });
            return Json(new
            {
                Status = -1,
                Data = "",
            });
        }

        [HttpPost]
        public IActionResult SearchProduct(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return null;
            var model = _productService.SearchProduct(keyword);
            if (model != null && model.Any())
                return Json(new
                {
                    Status = 1,
                    Data = JsonConvert.SerializeObject(model),
                });
            return Json(new
            {
                Status = -1,
                Data = "",
            });
        }



        [HttpPost]
        public IActionResult CreateOrder(int CustomerId, string CustomerPhone, string CustomerName, string CustomerAddress, string CustomerNote)
        {
            bool IsSavedCustomer = false;
            if(CustomerId == 0)
            {
                var newContact = new Contacts();
                newContact.FullName = CustomerName;
                newContact.Contents = CustomerNote;
                newContact.Address = CustomerAddress;
                newContact.Phone = CustomerPhone;
                IsSavedCustomer = _productService.Create(newContact);
            }

            if (!IsSavedCustomer)
            {
                return Json(new
                {
                    Status = -1,
                    Data = "Không lưu được thông tin khách hàng, vui lòng thử lại sau.",
                });
            }

            return Json(new
            {
                Status = -1,
                Data = "",
            });
        }

        private void WriteCookie(string name, string value, int days = 10)
        {
            Response.Cookies.Append(name, value, new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Expires = DateTime.Now.AddDays(days),
            });
        }

        private void DeleteCookie(string name)
        {
            Response.Cookies.Append(name, "", new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1),
            });
        }

        private string ReadCookie(string name)
        {
            return Request.Cookies[name];
        }

        private List<ProductCart> GetCoreBrain()
        {
            var jsonCart = ReadCookie("PMCB");
            if(!string.IsNullOrEmpty(jsonCart))
            {
                var lstPro = JsonConvert.DeserializeObject<List<CoreBrain>>(jsonCart);
                if(lstPro != null && lstPro.Any())
                {
                    var listCarts = new List<ProductCart>();
                    foreach(var item in lstPro)
                    {
                        var model = _productService.Get(item.ProductId);
                        if(model != null)
                        {
                            var p = new ProductCart();
                            p.Product = model;
                            p.Quantity = item.Quantity;
                            p.Price = model.Price.Value;
                            listCarts.Add(p);
                        }

                    }
                    return listCarts;
                }
                return null;
            }
            return null;
        }

    }
}
