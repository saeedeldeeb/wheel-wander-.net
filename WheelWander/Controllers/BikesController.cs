using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WheelWander.Repositories;
using WheelWander.Consts;
using WheelWander.ViewModels.Bikes;

namespace WheelWander.Controllers;
[Authorize(Roles = "Admin")]
public class BikesController :Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public BikesController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    [HttpGet("/bikes")]
    public IActionResult List()
    {
        dynamic model = new ExpandoObject();
        model.Bikes = _unitOfWork.Bikes
            .FindAll(b => b.Status == Status.Active || b.Status == Status.Maintenance,
                new[] { "CurrentStation" });
        model.Locks = _unitOfWork.Locks
            .FindAll(l => l.Status == Status.Active || l.Status == Status.Maintenance,
                new[] { "Bike" });
        
        return View("../Dashboard/Bikes", new BikesViewModel(model));
    }
}