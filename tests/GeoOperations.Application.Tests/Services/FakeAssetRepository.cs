using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;

namespace GeoOperations.Application.Tests.Services;

internal sealed class FakeAssetRepository : IAssetRepository
{
    private readonly IReadOnlyCollection<Asset> _assets;

    public FakeAssetRepository(IReadOnlyCollection<Asset> assets)
    {
        _assets = assets;
    }

    public IReadOnlyCollection<Asset> GetAll()
    {
        return _assets;
    }
}
