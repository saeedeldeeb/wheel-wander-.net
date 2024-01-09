using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace WheelWander.ViewModels.Stations;

public class StationViewModel
{
    public string Id { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please Enter Station Name")]
    public string StationName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please Enter Station Capacity")]
    [Range(1, 10, ErrorMessage = "Please Enter Valid Station Capacity")]
    public int StationCapacity { get; set; }
    [Required(ErrorMessage = "Please Enter Station Status")]
    public string Status { get; set; } = string.Empty;
    public int AvailableBikes { get; set; }
    public Point? Location { get; set; } = null;
}