namespace WheelWander.Models;

public class Bike
{
    public string Id { get; set; }
    
    public int BikeNumber { get; set; }

    public string Status { get; set; }
    
    public string? CurrentStationId { get; set; }

    public Station CurrentStation { get; set; }
}