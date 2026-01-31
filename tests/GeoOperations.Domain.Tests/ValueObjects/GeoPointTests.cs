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
}
