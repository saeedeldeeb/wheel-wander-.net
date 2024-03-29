using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WheelWander.Consts;
using WheelWander.Repositories;

namespace WheelWander.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

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
            var rentals = _unitOfWork.Rentals
                .FindAll(r => r.Status == Status.Active || r.Status == Status.Completed,
                    new[] { "Bike", "User", "StartStation", "EndStation" });
            return View(rentals);
        }
        
    }
}