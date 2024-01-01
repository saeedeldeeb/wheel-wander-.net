using NetTopologySuite.Geometries;

namespace WheelWander.Models;

public class Station
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public Point Location { get; set; }
    
    public int Capacity { get; set; }
    
    public List<Bike> Bikes { get; set; }
    
    public string Status { get; set; }
}