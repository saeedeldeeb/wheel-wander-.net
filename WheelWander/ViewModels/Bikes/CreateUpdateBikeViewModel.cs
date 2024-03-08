using System.ComponentModel.DataAnnotations;
using WheelWander.Consts;
using WheelWander.Models;
using WheelWander.Vailidation;

namespace WheelWander.ViewModels.Bikes;

public class CreateUpdateBikeViewModel
{
    public string Id { get; set; } = String.Empty;
   [Required(ErrorMessage = "Status is required")]
   [CustomValidationBike(ErrorMessage = "Invalid status or station ID")]
    public string status { get; set; }
    [Required(ErrorMessage = "Current station ID is required")]
    //[CustomValidationBike(ErrorMessage = "Station ID does not exist")]
    public string currentStationId { get; set; }
    [Required(ErrorMessage = "Bike number is required")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Bike number must be an integer")]
    public int bikeNumber { get; set; }
    
}
