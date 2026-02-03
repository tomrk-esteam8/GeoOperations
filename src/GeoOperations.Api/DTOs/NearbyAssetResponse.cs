namespace GeoOperations.Api.DTOs;

public sealed record NearbyAssetResponse(
    Guid Id,
    string Name,
    double DistanceKm);
