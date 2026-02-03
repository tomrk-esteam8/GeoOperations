using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.DTOs;

public sealed record NearbyAssetResult(
    Guid AssetId,
    string Name,
    Distance Distance);
