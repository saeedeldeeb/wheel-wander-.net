using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WheelWander.Consts;
using WheelWander.Repositories;
using Newtonsoft.Json;

namespace WheelWander.Controllers.Api
{

[Route("api/stations")]
[ApiController]
[Authorize(Roles = "User")]
    public class StationsApiController: ControllerBase
    {
     private readonly IUnitOfWork _unitOfWork;

    public StationsApiController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public IActionResult List()
    {
        var stations = _unitOfWork.Stations
              .FindAll(s => s.Status == Status.Active);
      var jsonSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        var json = JsonConvert.SerializeObject(stations, jsonSettings);

        return Content(json, "application/json");
    }
        

    }
}