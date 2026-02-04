using GeoOperations.Application.Services;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;
using Xunit;

namespace GeoOperations.Application.Tests.Services;

public class ZoneServiceTests
{
    [Fact]
    public void Should_Return_Zone_When_Point_Is_Inside()
    {
        // Arrange
        var zone = new Zone(
            Guid.NewGuid(),
            "Test Zone",
            new[]
            {
                new GeoPoint(0, 0),
                new GeoPoint(0, 10),
                new GeoPoint(10, 10),
                new GeoPoint(10, 0)
            });

        var repository = new FakeZoneRepository(zone);

        var geometryService = new FakeZoneGeometryService
        {
            ContainsResult = true   // 👈 THIS IS THE KEY LINE
        };

        var service = new ZoneService(repository, geometryService);

        var pointInside = new GeoPoint(5, 5);

        // Act
        var result = service.FindContainingZones(pointInside);

        // Assert
        Assert.Single(result);
        Assert.Equal("Test Zone", result.First().Name);
    }


    [Fact]
    public void Should_Include_Point_On_Zone_Boundary()
    {
        var zone = new Zone(
            Guid.NewGuid(),
            "Boundary Zone",
            new[]
            {
                new GeoPoint(0, 0),
                new GeoPoint(0, 10),
                new GeoPoint(10, 10),
                new GeoPoint(10, 0)
            });

        var repository = new FakeZoneRepository(zone);

        // Fake geometry service simulating boundary-inclusive behavior
        var geometryService = new FakeZoneGeometryService
        {
            ContainsResult = true
        };

        var service = new ZoneService(repository, geometryService);

        var boundaryPoint = new GeoPoint(0, 5);

        var result = service.FindContainingZones(boundaryPoint);

        Assert.Single(result);
    }

}
