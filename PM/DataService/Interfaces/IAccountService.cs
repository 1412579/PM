using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Models;
namespace DataService.Interfaces
{
    public interface IAccountService
    {
        Users Login(string username,string password);
    }
}
