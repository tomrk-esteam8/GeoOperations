using GeoOperations.Domain.ValueObjects;

namespace GeoOperations.Domain.Entities;

public sealed class Zone
{
    public Guid Id { get; }
    public string Name { get; }
    public IReadOnlyCollection<GeoPoint> Boundary { get; }

    public Zone(Guid id, string name, IReadOnlyCollection<GeoPoint> boundary)
    {
        if (name is null)
            throw new ArgumentNullException(nameof(name));

        if (boundary is null)
            throw new ArgumentNullException(nameof(boundary));

        if (boundary.Count < 3)
            throw new ArgumentException(
                "Zone must have at least 3 points.",
                nameof(boundary));

        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Boundary = boundary;
    }
}
