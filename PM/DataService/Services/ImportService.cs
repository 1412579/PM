using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Interfaces;
using DataService.Interfaces;
using PM.Models;

namespace DataService.Services
{
    public class ImportService : IImportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductImport> _importRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ImportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _importRepository = _unitOfWork.Repository<ProductImport>();
        }

        public bool Create(ProductImport model)
        {
            try
            {
                _importRepository.Add(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ProductImport Get(int idp)
        {
            return _importRepository.Get(x => x.ImportId == idp && x.IsDelete != true);
        }

        public List<ProductImport> GetAll(int page = -1, int size = 10)
        {
            try
            {
                var rsl = _importRepository.GetAll(x => x.IsDelete != true);
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

        public List<ProductImport> GetAllByProductId(int id)
        {
            try
            {
                return _importRepository.GetAll(x => x.IsDelete != true && x.ProductId == id).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int GetInStock(int id)
        {
            var stock = 0;
            var lstImport = GetAllByProductId(id);
            if (lstImport != null && lstImport.Any())
                stock = lstImport.Sum(x => x.Quantity.Value);
            return stock;
        }

        public List<ProductImport> Search(string keyWord)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductImport model)
        {
            try
            {
                _importRepository.Update(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
