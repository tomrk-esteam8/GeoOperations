using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;
using NetTopologySuite.Geometries;

namespace GeoOperations.Infrastructure.Geometry;

internal static class GeometryFactoryAdapter
{
    private static readonly GeometryFactory Factory =
        NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

    public static Point ToPoint(GeoPoint geoPoint)
        => Factory.CreatePoint(new Coordinate(geoPoint.Longitude, geoPoint.Latitude));

    public static Polygon ToPolygon(Zone zone)
    {
        var coordinates = zone.Boundary
            .Select(p => new Coordinate(p.Longitude, p.Latitude))
            .Append(new Coordinate(
                zone.Boundary.First().Longitude,
                zone.Boundary.First().Latitude))
            .ToArray();

        return Factory.CreatePolygon(coordinates);
    }
}
