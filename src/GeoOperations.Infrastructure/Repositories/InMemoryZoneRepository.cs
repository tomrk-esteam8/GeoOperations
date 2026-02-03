using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Infrastructure.Repositories;

public sealed class InMemoryZoneRepository : IZoneRepository
{
    private static readonly IReadOnlyCollection<Zone> Zones =
    [
        new Zone(
            Guid.NewGuid(),
            "Berlin Zone",
            new[]
            {
                new GeoPoint(52.6, 13.2),
                new GeoPoint(52.6, 13.6),
                new GeoPoint(52.4, 13.6),
                new GeoPoint(52.4, 13.2)
            })
    ];

    public IReadOnlyCollection<Zone> GetAll() => Zones;
}
