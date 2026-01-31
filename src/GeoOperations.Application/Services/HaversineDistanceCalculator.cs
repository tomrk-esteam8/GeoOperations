using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Services;

public sealed class HaversineDistanceCalculator : IGeoDistanceCalculator
{
    private const double EarthRadiusMeters = 6_371_000;

    public Distance Calculate(GeoPoint from, GeoPoint to)
    {
        if (from == to)
            return Distance.FromMeters(0);

        var lat1 = DegreesToRadians(from.Latitude);
        var lat2 = DegreesToRadians(to.Latitude);
        var deltaLat = DegreesToRadians(to.Latitude - from.Latitude);
        var deltaLon = DegreesToRadians(to.Longitude - from.Longitude);

        var a =
            Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
            Math.Cos(lat1) * Math.Cos(lat2) *
            Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var distance = EarthRadiusMeters * c;

        return Distance.FromMeters(distance);
    }

    private static double DegreesToRadians(double degrees)
        => degrees * Math.PI / 180.0;
}
