using WheelWander.Models;
using WheelWander.Repositories.Implementations;
using WheelWander.Repositories.Interfaces;

namespace WheelWander.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly WheelWanderDbContext _context;

    public IBaseRepository<Station> Stations { get; private set; }
    public IBaseRepository<Bike> Bikes { get; private set; }
    public IBaseRepository<Rental> Rentals { get; private set; }
    
    public IBaseRepository<Lock> Locks { get; private set; }

    public UnitOfWork(WheelWanderDbContext context)
    {
        _context = context;
        Stations = new BaseRepository<Station>(_context);
        Bikes = new BaseRepository<Bike>(_context);
        Rentals = new BaseRepository<Rental>(_context);
        Locks = new BaseRepository<Lock>(_context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}