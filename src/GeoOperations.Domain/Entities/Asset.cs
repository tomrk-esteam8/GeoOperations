using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Domain.Entities;

public sealed class Asset
{
    public Guid Id { get; }
    public string Name { get; }
    public GeoPoint Location { get; }

    public Asset(Guid id, string name, GeoPoint location)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Location = location ?? throw new ArgumentNullException(nameof(location));
    }
}
