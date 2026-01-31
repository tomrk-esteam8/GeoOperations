using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Application.Interfaces;

public interface IGeoDistanceCalculator
{
    Distance Calculate(GeoPoint from, GeoPoint to);
}
