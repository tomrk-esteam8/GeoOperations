using GeoOperations.Domain.ValueObjects;
using Xunit;

namespace GeoOperations.Domain.Tests.ValueObjects;

public class DistanceTests
{
    [Fact]
    public void Should_Create_Distance_From_Meters()
    {
        var distance = Distance.FromMeters(1500);

        Assert.Equal(1500, distance.Meters);
        Assert.Equal(1.5, distance.ToKilometers());
    }

    [Fact]
    public void Should_Create_Distance_From_Kilometers()
    {
        var distance = Distance.FromKilometers(2);

        Assert.Equal(2000, distance.Meters);
    }

    [Fact]
    public void Should_Throw_When_Distance_Is_Negative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Distance.FromMeters(-1));
    }

    [Fact]
    public void Zero_Distance_Should_Be_Valid()
    {
        var distance = Distance.FromMeters(0);

        Assert.Equal(0, distance.Meters);
    }

    public void Should_Throw_When_Distance_Is_NaN()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Distance.FromMeters(double.NaN));
    }
}
