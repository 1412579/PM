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
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        //ILogger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public AccountService(IUnitOfWork unitOfWork)
        {
            //_promotionRepository = unitOfWork.Repository<Promotion>();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Hàm kiểm tra đăng nhập theo username và password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Users Login(string username, string password)
        {
            IRepository<Users> repository = _unitOfWork.Repository<Users>();
            Users result;
            try
            {
                result = repository.Get(a => a.UserName == username && a.Password == PM.lib.CrytoHelper.GetMD5Hash(password));
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
