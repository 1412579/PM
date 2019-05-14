using System;
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
    }
}
