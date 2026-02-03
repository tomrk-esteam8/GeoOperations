using GeoOperations.Application.DTOs;
using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Services;

public sealed class AssetService : IAssetService
{
    private readonly IAssetRepository _repository;
    private readonly IGeoDistanceCalculator _distanceCalculator;

    public AssetService(
        IAssetRepository repository,
        IGeoDistanceCalculator distanceCalculator)
    {
        _repository = repository;
        _distanceCalculator = distanceCalculator;
    }

    public IReadOnlyCollection<NearbyAssetResult> FindNearby(
        GeoPoint origin,
        Distance radius)
    {
        return _repository
            .GetAll()
            .Select(asset =>
            {
                var distance = _distanceCalculator.Calculate(origin, asset.Location);
                return new { asset, distance };
            })
            .Where(x => x.distance.Meters <= radius.Meters)
            .OrderBy(x => x.distance.Meters)
            .Select(x =>
                new NearbyAssetResult(
                    x.asset.Id,
                    x.asset.Name,
                    x.distance))
            .ToList();
    }

    IReadOnlyCollection<NearbyAssetResult> IAssetService.FindNearby(GeoPoint origin, Distance radius)
    {
        throw new NotImplementedException();
    }
}
