using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WheelWander.Models;

public class WheelWanderDbContext : IdentityDbContext
{
    public WheelWanderDbContext(DbContextOptions<WheelWanderDbContext> options) : base(options)
    {
    }
    
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Lock> Locks { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Station> Stations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        const string adminId = "fcdb4a01-a1be-4d5b-92e4-08b1163f47c7";
        const string userId = "0de8240e-0bfc-492d-9758-d041c1314812";
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = adminId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "217ca5d6-29ce-4c73-8b92-de50c09f97f0"
            },
            new IdentityRole
            {
                Id = userId,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "678e1b6a-9a0c-4fdd-8bca-130ee693e2ae"
            }
        );

        // Generate a new random UUID
        const string saeedId = "accd2e8c-8355-4be6-b14d-d92e16529648";
        const string showmanId = "5c621b1c-a866-4726-8e6a-a170b9c03472";
        builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = saeedId,
                UserName = "saeedeldeeb1",
                NormalizedUserName = "SAEEDELDEEB1",
                Email = "saeedeldeeb1@gmail.com",
                NormalizedEmail = "SAEEDELDEEB1@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAELtwAkdp2tkBKWYD6ed6ldNlmW0at8daYpulpOAozyyqmI4IBLjlmjM71EpoG9IMKg==",
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "e36d365f-6b85-44a9-9a95-6a4d72e9a586"
            },
            new IdentityUser
            {
                Id = showmanId,
                UserName = "showmanAhmed",
                NormalizedUserName = "SHOWMANAHMED",
                Email = "showmanAhmed@gmail.com",
                NormalizedEmail = "SHOWMANAHMED@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEJ3oZqqQplbgosNBFkavHMEJsbc4169BRYbm5jED9IMan/8U7ITr2+JRxWxkmryQCQ==",
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "d33e4e53-cb92-411a-bec6-1de8f9463b0c"
            }
        );
        
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminId,
                UserId = saeedId
            },
            new IdentityUserRole<string>
            {
                RoleId = userId,
                UserId = showmanId
            }
        );
    }
}