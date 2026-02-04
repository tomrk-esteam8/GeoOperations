using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Tests.Services;

internal sealed class FakeZoneGeometryService : IZoneGeometryService
{
    public bool ContainsResult { get; set; }

    public bool Contains(Zone zone, GeoPoint point)
    {
        return ContainsResult;
    }
}
