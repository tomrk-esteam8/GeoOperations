using GeoOperations.Domain.Entities;

namespace GeoOperations.Application.Interfaces;

public interface IAssetRepository
{
    IReadOnlyCollection<Asset> GetAll();
}
