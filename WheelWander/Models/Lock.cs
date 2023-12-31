namespace WheelWander.Models;

public class Lock
{
    public string Id { get; set; }

    public string? BikeId { get; set; }
    
    public Bike? Bike { get; set; }
    
    public int DeviceNumber { get; set; }
    
    public string PowerLevel { get; set; }
    
    public string Status { get; set; }
}