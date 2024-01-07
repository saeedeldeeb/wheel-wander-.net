using WheelWander.Models;

namespace WheelWander.ViewModels.Stations;

public class StationListViewModel
{
    public IEnumerable<Station> Stations { get; }
    
    public StationListViewModel(IEnumerable<Station> stations)
    {
        Stations = stations;
    }
}