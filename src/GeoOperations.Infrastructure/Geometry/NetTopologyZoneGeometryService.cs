using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;
using NetTopologySuite.Geometries;

namespace GeoOperations.Infrastructure.Geometry;

// IMPORTANT:
// NetTopologySuite expects coordinates as (longitude, latitude)
// SRID 4326 = WGS84 (standard GPS coordinates)

public sealed class NetTopologyZoneGeometryService : IZoneGeometryService
{
    private static readonly GeometryFactory Factory =
        NetTopologySuite.NtsGeometryServices.Instance
            .CreateGeometryFactory(srid: 4326);

    public bool Contains(Zone zone, GeoPoint point)
    {
        var polygon = ToPolygon(zone);
        var geometryPoint = ToPoint(point);

        return polygon.Contains(geometryPoint) 
            || polygon.Touches(geometryPoint);
    }

    private static Point ToPoint(GeoPoint geoPoint)
        => Factory.CreatePoint(
            new Coordinate(geoPoint.Longitude, geoPoint.Latitude));

    private static Polygon ToPolygon(Zone zone)
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
