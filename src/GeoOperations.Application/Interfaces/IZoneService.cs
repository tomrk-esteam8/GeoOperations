using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Interfaces;

public interface IZoneService
{
    IReadOnlyCollection<Zone> FindContainingZones(GeoPoint point);
}
