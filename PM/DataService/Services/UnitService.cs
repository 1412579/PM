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
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductUnit> _productUnitRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="unitOfWork"></param>
        public UnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productUnitRepository = _unitOfWork.Repository<ProductUnit>();
        }

        public bool Create(ProductUnit unit)
        {
            try
            {
                _productUnitRepository.Add(unit);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ProductUnit Get(int idp)
        {
            return _productUnitRepository.Get(x=>x.UnitId == idp && x.IsDelete != true);
        }

        public List<ProductUnit> GetAll(int page = -1, int size = 10)
        {
            try
            {
                var rsl = _productUnitRepository.GetAll(x => x.IsDelete != true);
                if(rsl != null && rsl.Any())
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

        public bool Update(ProductUnit model)
        {
            try
            {
                _productUnitRepository.Update(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        List<ProductUnit> IUnitService.Search(string keyWord)
        {
            throw new NotImplementedException();
        }
    }
}
