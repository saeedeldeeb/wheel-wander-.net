using System.Dynamic;

namespace WheelWander.ViewModels.Bikes;

public class BikesViewModel
{
    public IEnumerable<ExpandoObject> ExpandObjects { get; }
    
    public BikesViewModel(IEnumerable<ExpandoObject> expandObject)
    {
        ExpandObjects = expandObject;
    }
}