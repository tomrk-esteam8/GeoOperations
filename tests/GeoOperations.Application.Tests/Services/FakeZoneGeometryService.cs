using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Tests.Services;

internal sealed class FakeZoneGeometryService : IZoneGeometryService
{
    public bool Contains(Zone zone, GeoPoint point)
    {
        // Very simple fake: test decides behavior
        return zone.Name == "Test Zone";
    }
}
