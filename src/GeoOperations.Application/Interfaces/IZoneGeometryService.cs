using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Interfaces;

public interface IZoneGeometryService
{
    bool Contains(Zone zone, GeoPoint point);
}
