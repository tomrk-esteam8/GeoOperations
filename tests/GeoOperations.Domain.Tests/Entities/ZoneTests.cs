using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;
using Xunit;

namespace GeoOperations.Domain.Tests.Entities;

public class ZoneTests
{
    [Fact]
    public void Should_Create_Zone_With_Valid_Boundary()
    {
        // Arrange
        var boundary = new[]
        {
            new GeoPoint(0, 0),
            new GeoPoint(0, 10),
            new GeoPoint(10, 10),
            new GeoPoint(10, 0)
        };

        // Act
        var zone = new Zone(
            Guid.NewGuid(),
            "Test Zone",
            boundary);

        // Assert
        Assert.Equal("Test Zone", zone.Name);
        Assert.Equal(4, zone.Boundary.Count);
    }

    [Fact]
    public void Should_Throw_When_Boundary_Has_Less_Than_Three_Points()
    {
        var boundary = new[]
        {
            new GeoPoint(0, 0),
            new GeoPoint(10, 10)
        };

        Assert.Throws<ArgumentException>(() =>
            new Zone(
                Guid.NewGuid(),
                "Invalid Zone",
                boundary));
    }

    [Fact]
    public void Should_Throw_When_Boundary_Is_Null()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new Zone(
                Guid.NewGuid(),
                "Null Boundary Zone",
                null!));
    }

    [Fact]
    public void Should_Throw_When_Name_Is_Null()
    {
        var boundary = new[]
        {
            new GeoPoint(0, 0),
            new GeoPoint(0, 10),
            new GeoPoint(10, 10)
        };

        Assert.Throws<ArgumentNullException>(() =>
            new Zone(
                Guid.NewGuid(),
                null!,
                boundary));
    }
}
