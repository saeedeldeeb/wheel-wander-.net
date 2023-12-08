using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WheelWander.Models;

public class WheelWanderDbContext : IdentityDbContext
{
    public WheelWanderDbContext(DbContextOptions<WheelWanderDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        );

        // Generate a new random UUID
        string saeedId = Guid.NewGuid().ToString();
        string showmanId = Guid.NewGuid().ToString();
        builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = saeedId,
                UserName = "saeedeldeeb1",
                NormalizedUserName = "SAEEDELDEEB1",
                Email = "saeedeldeeb1@gmail.com",
                NormalizedEmail = "SAEEDELDEEB1@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Saeed@123"),
                SecurityStamp = string.Empty
            },
            new IdentityUser
            {
                Id = showmanId,
                UserName = "showmanAhmed",
                NormalizedUserName = "SHOWMANAHMED",
                Email = "showmanAhmed@gmail.com",
                NormalizedEmail = "SHOWMANAHMED@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Showman@123"),
                SecurityStamp = string.Empty
            }
        );
        
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = saeedId
            },
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = showmanId
            }
        );
    }
}