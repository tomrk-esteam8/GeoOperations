using GeoOperations.Domain.ValueObjects;
using Xunit;

namespace GeoOperations.Domain.Tests.ValueObjects;

public class GeoPointTests
{
    [Fact]
    public void Should_Create_GeoPoint_When_Coordinates_Are_Valid()
    {
        var point = new GeoPoint(52.52, 13.405);

        Assert.Equal(52.52, point.Latitude);
        Assert.Equal(13.405, point.Longitude);
    }

    [Theory]
    [InlineData(-91, 0)]
    [InlineData(91, 0)]
    public void Should_Throw_When_Latitude_Is_Out_Of_Range(double lat, double lon)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new GeoPoint(lat, lon));
    }

    [Theory]
    [InlineData(0, -181)]
    [InlineData(0, 181)]
    public void Should_Throw_When_Longitude_Is_Out_Of_Range(double lat, double lon)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new GeoPoint(lat, lon));
    }

    [Fact]
    public void Should_Allow_Latitude_And_Longitude_On_Boundary()
    {
        var point = new GeoPoint(90, 180);

        Assert.Equal(90, point.Latitude);
        Assert.Equal(180, point.Longitude);
    }

    [Fact]
    public void Should_Throw_When_Latitude_Is_NaN()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new GeoPoint(double.NaN, 0));
    }

    [Fact]
    public void Should_Throw_When_Longitude_Is_NaN()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new GeoPoint(0, double.NaN));
    }


}
