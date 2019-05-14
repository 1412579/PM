using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Models;
namespace DataService.Interfaces
{
    public interface IUnitService
    {
        List<ProductUnit> GetAll(int page = -1, int size = -1);
        ProductUnit Get(int id);
        List<ProductUnit> Search(string keyWord);
        bool Create(ProductUnit unit);
        bool Update(ProductUnit unit);
    }
}
