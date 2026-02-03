using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;

namespace GeoOperations.Application.Tests.Services;

internal sealed class FakeZoneRepository : IZoneRepository
{
    private readonly IReadOnlyCollection<Zone> _zones;

    public FakeZoneRepository(params Zone[] zones)
    {
        _zones = zones;
    }

    public IReadOnlyCollection<Zone> GetAll()
    {
        return _zones;
    }
}