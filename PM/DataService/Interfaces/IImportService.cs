using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Models;
namespace DataService.Interfaces
{
    public interface IImportService
    {
        List<ProductImport> GetAll(int page = -1, int size = -1);
        ProductImport Get(int idp);
        List<ProductImport> Search(string keyWord);
        List<ProductImport> GetAllByProductId(int id);

        bool Create(ProductImport model);
        bool Update(ProductImport model);
        int GetInStock(int id);

    }
}
