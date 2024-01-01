using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WheelWander.Consts;
using WheelWander.Repositories;
using WheelWander.ViewModels.Stations;

namespace WheelWander.Controllers;

[Authorize(Roles = "Admin")]
public class StationsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public StationsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("/stations")]
    public IActionResult GetAll()
    {
        var stations = _unitOfWork.Stations
            .FindAll(s => s.Status == Status.Active, new[] { "Bikes" });
        return View("../Dashboard/Stations", new StationListViewModel(stations));
    }
}