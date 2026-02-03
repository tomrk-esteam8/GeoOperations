using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Services;

public sealed class ZoneService : IZoneService
{
    private readonly IZoneRepository _repository;
    private readonly IZoneGeometryService _geometryService;

    public ZoneService(
        IZoneRepository repository,
        IZoneGeometryService geometryService)
    {
        _repository = repository;
        _geometryService = geometryService;
    }

    public IReadOnlyCollection<Zone> FindContainingZones(GeoPoint point)
    {
        return _repository
            .GetAll()
            .Where(zone => _geometryService.Contains(zone, point))
            .ToList();
    }
}
