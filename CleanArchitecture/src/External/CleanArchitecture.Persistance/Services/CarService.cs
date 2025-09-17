using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Services;
public sealed class CarService : ICarService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CarService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        //AutoMapper kullanmadan önceki hali bu.
        //Car car = new()
        //{
        //    Name = request.Name,
        //    Model = request.Model,
        //    EnginePower = request.EnginePower
        //};

        //AutoMapper
        Car car = _mapper.Map<Car>(request);

        await _context.Set<Car>().AddAsync(car, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
