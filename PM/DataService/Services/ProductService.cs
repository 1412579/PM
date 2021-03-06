﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Interfaces;
using DataService.Interfaces;
using PM.Models;

namespace DataService.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Products> _productRepository;
        private readonly IRepository<Contacts> _contactRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;

        private readonly ICategoryService _categoryService;
        private readonly IImportService _importService;

        private readonly IUnitService _unitService;


        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ProductService(IUnitOfWork unitOfWork, ICategoryService categoryService, IUnitService unitService, IImportService importService)
        {
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.Repository<Products>();
            _contactRepository = _unitOfWork.Repository<Contacts>();
            _orderRepository = _unitOfWork.Repository<Order>();
            _orderItemRepository = _unitOfWork.Repository<OrderItem>();
            _unitService = unitService;
            _categoryService = categoryService;
            _importService = importService;
        }

        public bool Create(Products model)
        {
            try
            {
                _productRepository.Add(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Products Get(long idp)
        {
            return _productRepository.Get(x => x.ProductId == idp && x.IsDelete != true);
        }

        public Products GetByCode(string code)
        {
            return _productRepository.Get(x => x.ProductCode == code && x.IsDelete != true);
        }

        public List<Products> GetAll(int page = -1, int size = 10)
        {
            try
            {
                var rsl = _productRepository.GetAll(x => x.IsDelete != true);
                if (rsl != null && rsl.Any())
                {
                    if (page == -1)
                        return rsl.ToList();
                    else
                        return rsl.Skip(size * page).Take(size).ToList();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<Products> Search(string keyWord)
        {
            throw new NotImplementedException();
        }

        public bool Update(Products model)
        {
            try
            {
                _productRepository.Update(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ProductView> BuildProductsListing()
        {
            var rsl = new List<ProductView>();
            var products = GetAll();
            if (products != null && products.Any())
            {
                var cates = _categoryService.GetAll();
                var units = _unitService.GetAll();
                foreach (var item in products)
                {
                    var model = new ProductView();
                    model.Product = item;
                    model.Category = cates.FirstOrDefault(x => x.CategoryId == item.CategoryId) ?? null;
                    model.Unit = units.FirstOrDefault(x => x.UnitId == item.UnitId) ?? null;
                    model.InStock = _importService.GetInStock((int)item.ProductId) - NoStock((int)item.ProductId);
                    rsl.Add(model);
                }
            }
            return rsl;
        }
        public ProductView GetFullProductById(int id)
        {
            var products = Get(id);
            if(products != null)
            {
                var model = new ProductView();
                model.Product = products;
                model.Category = _categoryService.Get(products.CategoryId.Value);
                model.Unit = _unitService.Get(products.UnitId.Value);
                model.InStock = _importService.GetInStock(id) - NoStock(id); 
                return model;
            }
            return null;
        }

        public Contacts GetContactsByPhone(string phone)
        {
            return _contactRepository.Get(x => x.Phone == phone);
        }

        public bool Create(Contacts model)
        {
            try
            {
                _contactRepository.Add(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ProductView> SearchProduct(string keyword)
        {
            keyword = keyword.ToLower();
            var lstRsl = BuildProductsListing();
            if(lstRsl != null && lstRsl.Any())
            {
                return lstRsl.Where(x => x.Product.ProductName.ToLower().Contains(keyword) || x.Product.ProductCode.ToLower().Contains(keyword) || x.Category.CategoryName.ToLower().Contains(keyword) || x.Product.ProductId.ToString().ToLower().Contains(keyword)).ToList();
            }
            return null;
        }

        public bool Update(Contacts model)
        {
            try
            {
                _contactRepository.Update(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Order model)
        {
            try
            {
                _orderRepository.Add(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create(OrderItem model)
        {
            try
            {
                _orderItemRepository.Add(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Order model)
        {
            try
            {
                _orderRepository.Update(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Order> GetAllOrder(int page = -1, int size = -1)
        {
            try
            {
                var rsl = _orderRepository.GetAll(x => x.Deleted != true);
                if (rsl != null && rsl.Any())
                {
                    if (page == -1)
                        return rsl.ToList();
                    else
                        return rsl.Skip(size * page).Take(size).ToList();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Order GetOrder(int idp)
        {
            return _orderRepository.Get(x => x.Id == idp && x.Deleted != true);
        }

        public List<OrderItem> GetAllOrderItems(int orderId)
        {
            return _orderItemRepository.GetAll(x => x.OrderId == orderId).ToList();

        }

        public int NoStock(int productId)
        {
            var nostock = 0;
            var listSold = _orderItemRepository.GetAll(x => x.ProductId == productId).ToList();
            if (listSold != null && listSold.Any())
            {
                var listOrderId = listSold.Select(x => x.OrderId).Distinct();
                foreach(var OrderId in listOrderId)
                {
                    var order = GetOrder(OrderId.Value);
                    if(order != null)
                    {
                        nostock += listSold.Where(x => x.OrderId == OrderId).Sum(x => x.Quantity.Value);
                    }
                }
            }
            return nostock;
        }
    }
}
