using GeoOperations.Application.DTOs;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Interfaces;

public interface IAssetService
{
    IReadOnlyCollection<NearbyAssetResult> FindNearby(
        GeoPoint origin,
        Distance radius);
}
