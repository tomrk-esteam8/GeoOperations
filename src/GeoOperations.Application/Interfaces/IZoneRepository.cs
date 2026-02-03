using GeoOperations.Domain.Entities;

namespace GeoOperations.Application.Interfaces;

public interface IZoneRepository
{
    IReadOnlyCollection<Zone> GetAll();
}
