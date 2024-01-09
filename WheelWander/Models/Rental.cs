using Microsoft.AspNetCore.Identity;

namespace WheelWander.Models;

public class Rental
{
    public string Id { get; set; }
    
    public string UserId { get; set; }
    
    public IdentityUser User { get; set; }
    
    public string StartStationId { get; set; }
    
    public Station StartStation { get; set; }
    
    public string? EndStationId { get; set; }
    
    public Station EndStation { get; set; }
    
    public string BikeId { get; set; }
    
    public Bike Bike { get; set; }
    
    public DateTime StartedAt { get; set; }
    
    public DateTime? EndedAt { get; set; }
    
    public string Status { get; set; }
}