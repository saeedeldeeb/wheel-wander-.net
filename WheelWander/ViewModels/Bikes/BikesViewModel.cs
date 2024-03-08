using System.Dynamic;
using Microsoft.IdentityModel.Abstractions;
using WheelWander.Models;

namespace WheelWander.ViewModels.Bikes;

public class BikesViewModel
{
    public IEnumerable<Bike> Bikes { get; }
    public IEnumerable<Lock> Locks { get; }
    
    public BikesViewModel(dynamic dynamicModel)
    {
        if (dynamicModel == null)
            throw new ArgumentNullException(nameof(dynamicModel));
        Bikes = dynamicModel.Bikes;
        Locks = dynamicModel.Locks;
    }
}