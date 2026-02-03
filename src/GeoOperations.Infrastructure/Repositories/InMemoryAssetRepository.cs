using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Infrastructure.Repositories;

public sealed class InMemoryAssetRepository : IAssetRepository
{
    private static readonly IReadOnlyCollection<Asset> Assets =
    [
        new Asset(Guid.NewGuid(), "Berlin Hub", new GeoPoint(52.5200, 13.4050)),
        new Asset(Guid.NewGuid(), "Paris Hub", new GeoPoint(48.8566, 2.3522)),
        new Asset(Guid.NewGuid(), "Munich Hub", new GeoPoint(48.1351, 11.5820))
    ];

    public IReadOnlyCollection<Asset> GetAll() => Assets;
}
