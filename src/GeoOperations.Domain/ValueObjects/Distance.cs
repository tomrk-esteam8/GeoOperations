namespace GeoOperations.Domain.ValueObjects;

public sealed record Distance
{
    private const double MetersPerKilometer = 1000.0;

    public double Meters { get; }

    private Distance(double meters)
    {
        if (double.IsNaN(meters) || double.IsInfinity(meters))
            throw new ArgumentOutOfRangeException(nameof(meters));
            
        if (meters < 0)
            throw new ArgumentOutOfRangeException(
                nameof(meters),
                "Distance cannot be negative.");

        Meters = meters;
    }

    public static Distance FromMeters(double meters)
        => new(meters);

    public static Distance FromKilometers(double kilometers)
        => new(kilometers * MetersPerKilometer);

    public double ToKilometers()
        => Meters / MetersPerKilometer;

    public override string ToString()
        => $"{ToKilometers():0.###} km";
}
