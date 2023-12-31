using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WheelWander.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Users()
        {
            return View();
        }
        
        public IActionResult Rentals()
        {
            return View();
        }
        
        // public IActionResult Bikes()
        // {
        //     return View();
        // }
        
        public IActionResult Stations()
        {
            return View();
        }
    }
}