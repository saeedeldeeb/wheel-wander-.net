using Microsoft.EntityFrameworkCore;
using WheelWander.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WheelWanderDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:WheelWanderDbContextConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
