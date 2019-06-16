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
        private IRepository<Users> _accountService;
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
            _accountService = _unitOfWork.Repository<Users>();
        }

        /// <summary>
        /// Hàm kiểm tra đăng nhập theo username và password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Users Login(string username, string password)
        {
            Users result;
            try
            {
                result = _accountService.Get(a => a.UserName == username && a.Password == PM.lib.CrytoHelper.GetMD5Hash(password));
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

        public bool Update(Users user)
        {
            try
            {
                user.Password = PM.lib.CrytoHelper.GetMD5Hash(user.Password);
                _accountService.Update(user);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Create(Users model)
        {
            try
            {
                model.Password = PM.lib.CrytoHelper.GetMD5Hash(model.Password);
                model.FullName = model.UserName;
                _accountService.Add(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
