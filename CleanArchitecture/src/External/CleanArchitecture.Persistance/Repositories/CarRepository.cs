using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using GenericRepository;

namespace CleanArchitecture.Persistance.Repositories;
public sealed class CarRepository : Repository<Car, ApplicationDbContext>, ICarRepository
{
    public CarRepository(ApplicationDbContext context) : base(context) { }
}
