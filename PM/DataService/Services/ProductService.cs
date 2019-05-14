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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Products> _productRepositor;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepositor = _unitOfWork.Repository<Products>();
        }

        public bool Create(Products model)
        {
            try
            {
                _productRepositor.Add(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Products Get(long idp)
        {
            return _productRepositor.Get(x => x.ProductId == idp && x.IsDelete != true);
        }

        public Products GetByCode(string code)
        {
            return _productRepositor.Get(x => x.ProductCode == code && x.IsDelete != true);
        }

        public List<Products> GetAll(int page = -1, int size = 10)
        {
            try
            {
                var rsl = _productRepositor.GetAll(x => x.IsDelete != true);
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
                _productRepositor.Update(model);
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
