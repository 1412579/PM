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
        private string CartCookie = "huymatlonCB";
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
                {
                    ViewBag.ListImport = _importService.GetAllByProductId(modelId);
                    ViewBag.NoStock = _productService.NoStock(modelId);
                }
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
            var so = BuildSO();
            return View(so);
        }

        public IActionResult OrderInfo(int modelId)
        {
            if (modelId <= 0)
                return RedirectToAction("ListOrder");
            var so = BuildSOFromDB(modelId);
            if (so.Products == null || so.Products.Count == 0)
                return RedirectToAction("ListOrder");
            return View(so);
        }

        public IActionResult UpdateOrder(int modelId)
        {
            var model = new Order();
            if (modelId > 0)
            {
                model = _productService.GetOrder(modelId);
                if (model != null)
                {
                    model.Deleted = true;
                    _productService.Update(model);
                }
            }
            return RedirectToAction("ListOrder");
        }

        public IActionResult ListOrder()
        {
            var model = _productService.GetAllOrder();
            return View(model);
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
        public IActionResult GetProducts()
        {
            var so = BuildSO();
            return PartialView(so);
        }

        [HttpPost]
        public IActionResult SearchProduct(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return Json(new
                {
                    Status = -1,
                    Data = "",
                });
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
            var so = BuildSO();
            if (so.Products == null || so.Products.Count == 0)
            {
                return Json(new
                {
                    Status = -1,
                    Data = "Không có thông tin sản phẩm, vui lòng thêm vào.",
                });
            }
            else if(so.Products.Any(x => x.Quantity > x.Product.InStock))
            {
                return Json(new
                {
                    Status = -1,
                    Data = "Giỏ hàng có chứa sản phẩm không còn đủ hàng để xuất, vui lòng kiểm tra lại.",
                });
            }

            bool IsSavedCustomer = false;
            var Contact = new Contacts();
            if(CustomerId == 0)
            {
                Contact.FullName = CustomerName;
                Contact.Contents = CustomerNote;
                Contact.Address = CustomerAddress;
                Contact.Phone = CustomerPhone;
                IsSavedCustomer = _productService.Create(Contact);
            }
            else
            {
                Contact = _productService.GetContactsByPhone(CustomerPhone);
                Contact.FullName = CustomerName;
                Contact.Contents = CustomerNote;
                Contact.Address = CustomerAddress;
                Contact.Phone = CustomerPhone;
                IsSavedCustomer = _productService.Update(Contact);
            }

            if (!IsSavedCustomer)
            {
                return Json(new
                {
                    Status = -1,
                    Data = "Không lưu được thông tin khách hàng, vui lòng thử lại sau.",
                });
            }

            so.Contact = Contact;

            var msgReturn = SaveCart(so);
            if (!string.IsNullOrEmpty(msgReturn))
            {
                return Json(new
                {
                    Status = -1,
                    Data = msgReturn,
                });
            }

            ClearCoreBrain();

            return Json(new
            {
                Status = 1,
                Data = "Đã tạo đơn xuất hàng thành công.",
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int productId,int quantity)
        {
            var lstCartNow = GetCoreBrain();
            if (lstCartNow == null)
                lstCartNow = new List<ProductCart>();
            var pro = _productService.GetFullProductById(productId);
            if(pro == null)
                return Json(new
                {
                    Status = -1,
                    Data = "Sản phẩm không còn tồn tại!",
                });
            if(lstCartNow.Any( x=> x.Product.Product.ProductId == productId))
            {
                var item = lstCartNow.FirstOrDefault(x => x.Product.Product.ProductId == productId);
                item.Quantity += quantity;
                item.Total = item.Quantity * item.Price;
            }
            else
            {
                lstCartNow.Add(new ProductCart()
                {
                    Product = pro,
                    Quantity = quantity,
                    Price = pro.Product.Price.Value
                });
            }
            
            if(lstCartNow != null && lstCartNow.Any())
            {
                SaveCoreBrain(lstCartNow);
                return Json(new
                {
                    Status = 1,
                    Data = "Đã thêm sản phẩm thành công",
                });
            }
            return Json(new
            {
                Status = -1,
                Data = "",
            });
        }

        [HttpPost]
        public IActionResult DeleteCB(int productId)
        {
            var lstCartNow = GetCoreBrain();
            if(lstCartNow == null)
                return Json(new
                {
                    Status = -1,
                    Data = "Giỏ hàng sản phẩm không tồn tại",
                });
            lstCartNow = lstCartNow.Where(x => x.Product.Product.ProductId != productId).ToList();
            SaveCoreBrain(lstCartNow);
            return Json(new
            {
                Status = 1,
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

        private SalesOrder BuildSO()
        {
            var so = new SalesOrder();
            var cbProducts = GetCoreBrain();
            if (cbProducts != null && cbProducts.Any())
            {
                so.Products = cbProducts;
                so.Total = cbProducts.Sum(x => x.Total);
            }
            return so;
        }

        private SalesOrder BuildSOFromDB(int OrderId)
        {
            var so = new SalesOrder();
            var model = new Order();
            if (OrderId > 0)
            {
                model = _productService.GetOrder(OrderId);
                if (model != null)
                {
                    var orderItems = _productService.GetAllOrderItems(model.Id);
                    if(orderItems != null && orderItems.Any())
                    {
                        so.Products = new List<ProductCart>();
                        so.Contact = _productService.GetContactsByPhone(model.ShippingPhone);
                        foreach (var item in orderItems)
                        {
                            var oitem = _productService.GetFullProductById(item.ProductId.Value);
                            if (oitem != null)
                            {
                                var p = new ProductCart();
                                p.Product = oitem;
                                p.Quantity = item.Quantity.Value;
                                p.Price = item.Price.Value;
                                p.Total = item.Price.Value * item.Quantity.Value;
                                so.Products.Add(p);
                            }
                        }
                        so.Total = so.Products.Sum(x => x.Total);
                    }
                }
            }
            return so;
        }

        private List<ProductCart> GetCoreBrain()
        {
            var jsonCart = ReadCookie(CartCookie);
            if(!string.IsNullOrEmpty(jsonCart))
            {
                var lstPro = JsonConvert.DeserializeObject<List<CoreBrain>>(jsonCart);
                if(lstPro != null && lstPro.Any())
                {
                    var listCarts = new List<ProductCart>();
                    foreach(var item in lstPro)
                    {
                        var model = _productService.GetFullProductById((int)item.ProductId);
                        if(model != null)
                        {
                            var p = new ProductCart();
                            p.Product = model;
                            p.Quantity = item.Quantity;
                            p.Price = model.Product.Price.Value;
                            p.Total = model.Product.Price.Value * item.Quantity;
                            listCarts.Add(p);
                        }

                    }
                    return listCarts;
                }
                return null;
            }
            return null;
        }

        private List<CoreBrain> ProductCart2CB(List<ProductCart> Products)
        {
            if(Products != null && Products.Any())
            {
                return Products.Select(x => new CoreBrain() { ProductId = x.Product.Product.ProductId, Quantity = x.Quantity }).ToList();
            }
            return null;
        }

        private void SaveCoreBrain(List<ProductCart> Products)
        {
            WriteCookie(CartCookie, JsonConvert.SerializeObject(ProductCart2CB(Products)));
        }


        private void ClearCoreBrain()
        {
            WriteCookie(CartCookie, "");
        }

        private string SaveCart(SalesOrder so)
        {
            var Order = new Order();
            Order.BillingAddress = so.Contact.Address;
            Order.Note = so.Contact.Contents;
            Order.OrderStatusId = 0;
            Order.PaymentStatusId = 0;
            Order.OrderTotal = so.Total;
            Order.ShippingName = so.Contact.FullName;
            Order.ShippingPhone = so.Contact.Phone;
            Order.ContactId = Convert.ToInt32(so.Contact.Id);
            var IsSavedOrder = _productService.Create(Order);
            if (!IsSavedOrder)
            {
                return "Không thể lưu thông tin Đơn xuất, vui lòng thử lại sau.";
            }

            foreach(var item in so.Products)
            {
                var orderItem = new OrderItem();
                orderItem.OrderId = Order.Id;
                orderItem.ProductId = Convert.ToInt32(item.Product.Product.ProductId);
                orderItem.Quantity = item.Quantity;
                orderItem.Price = item.Product.Product.Price;
                if (!_productService.Create(orderItem))
                {
                    Order.Deleted = true;
                    _productService.Update(Order);
                    return "Không thể lưu thông tin sản phẩm Đơn xuất, vui lòng thử lại sau.";
                }
            }
            return "";
        }

    }
}
