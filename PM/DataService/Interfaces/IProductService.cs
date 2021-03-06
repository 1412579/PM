﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Models;
namespace DataService.Interfaces
{
    public interface IProductService
    {
        List<Products> GetAll(int page = -1, int size = -1);
        Products Get(long idp);
        List<Products> Search(string keyWord);
        bool Create(Products product);
        bool Update(Products product);
        Products GetByCode(string code);
        List<ProductView> BuildProductsListing();
        ProductView GetFullProductById(int id);
        List<ProductView> SearchProduct(string keyword);

        Contacts GetContactsByPhone(string phone);
        bool Create(Contacts model);
        bool Update(Contacts model);
        bool Create(Order model);
        bool Create(OrderItem model);
        bool Update(Order model);
        Order GetOrder(int idp);

        List<Order> GetAllOrder(int page = -1, int size = -1);
        List<OrderItem> GetAllOrderItems(int orderId);
        int NoStock(int productId);

    }
}
