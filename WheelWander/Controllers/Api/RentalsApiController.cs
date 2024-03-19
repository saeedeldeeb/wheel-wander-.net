using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WheelWander.Consts;
using WheelWander.Models;
using WheelWander.Repositories;
using WheelWander.ViewModels.Rentals;

namespace WheelWander.Controllers.Api;

[Route("api/rentals")]
[ApiController]
[Authorize(Roles = "User")]
public class RentalsApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public RentalsApiController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public IActionResult RentBike(RentBikeViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _unitOfWork.Rentals.Add(new Rental
        {
            Id = Guid.NewGuid().ToString(),
            UserId = User.FindFirstValue("uid"),
            BikeId = model.BikeId,
            StartStationId = model.StartStationId,
            StartedAt = DateTime.Now,
            Status = Status.Active
        });
        _unitOfWork.Complete();

        return Ok(model);
    }
}
