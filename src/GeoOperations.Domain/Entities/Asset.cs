using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Domain.Entities;

public sealed class Asset
{
    public Guid Id { get; }
    public string Name { get; }
    public GeoPoint Location { get; }

    public Asset(Guid id, string name, GeoPoint location)
    {
        if (name is null)
            throw new ArgumentNullException(nameof(name));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Asset name cannot be empty.", nameof(name));

        if (location is null)
            throw new ArgumentNullException(nameof(location));

        Id = id;
        Name = name;
        Location = location;
    }

}
