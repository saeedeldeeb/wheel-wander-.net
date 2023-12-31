using WheelWander.Models;
using WheelWander.Repositories.Implementations;
using WheelWander.Repositories.Interfaces;

namespace WheelWander.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly WheelWanderDbContext _context;

    public IBaseRepository<Station> Stations { get; private set; }

    public UnitOfWork(WheelWanderDbContext context)
    {
        _context = context;
        Stations = new BaseRepository<Station>(_context);
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