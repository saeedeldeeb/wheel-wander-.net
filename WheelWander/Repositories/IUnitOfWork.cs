using WheelWander.Models;
using WheelWander.Repositories.Interfaces;

namespace WheelWander.Repositories;

public interface IUnitOfWork: IDisposable
{
    IBaseRepository<Station> Stations { get; }
    IBaseRepository<Bike> Bikes { get; }
    IBaseRepository<Rental> Rentals { get; }
    IBaseRepository<Lock> Locks { get; }
    
    int Complete();
}