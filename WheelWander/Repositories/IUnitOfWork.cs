using WheelWander.Models;
using WheelWander.Repositories.Interfaces;

namespace WheelWander.Repositories;

public interface IUnitOfWork: IDisposable
{
    IBaseRepository<Station> Stations { get; }
    
    int Complete();
}