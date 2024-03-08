using Microsoft.AspNetCore.Mvc.Rendering;
using WheelWander.Models;

namespace WheelWander.ViewModels.Bikes;

public class BikeViewModel
{
    public string Id { get; }
    public string status { get; }
    public string currentStationName { get; }
    public int bikeNumber { get; }
    public string currentStationId { get; }
    public List<SelectListItem> Stations { get; }
    public BikeViewModel(Bike? bike, List<Station> stations)
    {
        if (bike == null)
            throw new ArgumentNullException();
        Id = bike.Id;
        status = bike.Status;
        bikeNumber = bike.BikeNumber;
        currentStationName = bike.CurrentStation?.Name ?? string.Empty;
        currentStationId = bike.CurrentStation?.Id ?? String.Empty;
        Stations = stations.Select(s => new SelectListItem { Value = s.Id, Text = s.Name }).ToList();
    }
}