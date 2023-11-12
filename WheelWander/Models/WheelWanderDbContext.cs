using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WheelWander.Models;

public class WheelWanderDbContext : IdentityDbContext
{
    public WheelWanderDbContext(DbContextOptions<WheelWanderDbContext> options) : base(options)
    {
    }
}