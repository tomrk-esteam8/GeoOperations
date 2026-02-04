namespace GeoOperations.Domain.ValueObjects;

public sealed record GeoPoint
{
    public double Latitude { get; }
    public double Longitude { get; }

    public GeoPoint(double latitude, double longitude)
    {
        if (double.IsNaN(latitude) || double.IsInfinity(latitude))
            throw new ArgumentOutOfRangeException(nameof(latitude));

        if (double.IsNaN(longitude) || double.IsInfinity(longitude))
            throw new ArgumentOutOfRangeException(nameof(longitude));
            
        if (latitude < -90 || latitude > 90)
            throw new ArgumentOutOfRangeException(
                nameof(latitude),
                "Latitude must be between -90 and 90.");

        if (longitude < -180 || longitude > 180)
            throw new ArgumentOutOfRangeException(
                nameof(longitude),
                "Longitude must be between -180 and 180.");

        Latitude = latitude;
        Longitude = longitude;
    }

    public override string ToString()
        => $"{Latitude}, {Longitude}";
}
