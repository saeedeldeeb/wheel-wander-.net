using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WheelWander.Models;
using System.Linq.Dynamic.Core;

namespace WheelWander.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly WheelWanderDbContext _context;

    public UsersController(WheelWanderDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    public IActionResult Get()
    {
        var pageSize = int.Parse(Request.Form["length"]);
        var skip = int.Parse(Request.Form["start"]);

        var searchValue = Request.Form["search[value]"];

        var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
        var sortColumnDirection = Request.Form["order[0][dir]"];

        var customers = _userManager.Users
            .Select(m => new
            {
                m.Id,
                m.UserName,
                m.Email,
                m.PhoneNumber,
                m.LockoutEnabled
            })
            .Where(m =>
            string.IsNullOrEmpty(searchValue) || 
            (m.UserName.Contains(searchValue) || m.Email.Contains(searchValue) ||
             m.PhoneNumber.Contains(searchValue) || m.Email.Contains(searchValue)));

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            customers = customers.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));

        var data = customers.Skip(skip).Take(pageSize).ToList();

        var recordsTotal = customers.Count();

        var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };

        return Ok(jsonData);
    }
}