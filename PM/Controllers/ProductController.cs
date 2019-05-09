using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataService.Services;
using DataService.Interfaces;
using PM.lib;
using Microsoft.AspNetCore.Authorization;

namespace PM.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult AddEdit(int productId)
        {
            return View();
        }
    }
}
