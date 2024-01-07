using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using WheelWander.Consts;
using WheelWander.Models;
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

    [HttpPost("/stations")]
    public IActionResult Create(StationViewModel station)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Stations.Add(new Station()
            {
                Id = Guid.NewGuid().ToString(),
                Name = station.StationName,
                Capacity = station.StationCapacity,
                Status = station.Status,
                Location = new Point(30.6046026,30.9990875) { SRID = 4326 }
            });
            _unitOfWork.Complete();
        }

        return RedirectToAction(nameof(GetAll));
    }
}