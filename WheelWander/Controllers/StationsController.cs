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
                Location = new Point(30.6046026, 30.9990875) { SRID = 4326 }
            });
            _unitOfWork.Complete();
        }

        return RedirectToAction(nameof(GetAll));
    }

    [HttpGet("/stations/{id}")]
    public IActionResult GetById(string id)
    {
        var station = _unitOfWork.Stations.Find(s => s.Id == id, new[] { "Bikes" });
        return View("../Dashboard/StationDetails", new StationViewModel()
        {
            Id = station?.Id ?? string.Empty,
            StationName = station?.Name ?? string.Empty,
            StationCapacity = station?.Capacity ?? 0,
            Status = station?.Status ?? string.Empty,
            AvailableBikes = station?.Bikes.Count ?? 0,
            Location = station?.Location
        });
    }

    [HttpPost("/stations/update")]
    public IActionResult Update(StationViewModel station)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Stations.Update(new Station()
            {
                Id = station.Id,
                Name = station.StationName,
                Capacity = station.StationCapacity,
                Status = station.Status,
                Location = new Point(30.6046026, 30.9990875) { SRID = 4326 }
            });
            _unitOfWork.Complete();
        }

        return RedirectToAction(nameof(GetAll));
    }
}