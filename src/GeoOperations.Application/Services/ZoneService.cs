using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;
using GeoOperations.Infrastructure.Geometry;

namespace GeoOperations.Application.Services;

public sealed class ZoneService : IZoneService
{
    private readonly IZoneRepository _repository;

    public ZoneService(IZoneRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyCollection<Zone> FindContainingZones(GeoPoint point)
    {
        var geometryPoint = GeometryFactoryAdapter.ToPoint(point);

        return _repository
            .GetAll()
            .Where(zone =>
                GeometryFactoryAdapter
                    .ToPolygon(zone)
                    .Contains(geometryPoint))
            .ToList();
    }
}
