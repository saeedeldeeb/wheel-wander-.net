using System.ComponentModel.DataAnnotations;

namespace WheelWander.ViewModels.Rentals;

public class RentBikeViewModel
{
    [Required]
    public string BikeId { get; set; }
    
    [Required]
    public string StartStationId { get; set; }
}