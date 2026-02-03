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
        var zone = new Zone(
            Guid.NewGuid(),
            "Test Zone",
            new[]
            {
                new GeoPoint(10, 10),
                new GeoPoint(10, 20),
                new GeoPoint(20, 20),
                new GeoPoint(20, 10)
            });

        var repository = new FakeZoneRepository(zone);
        var service = new ZoneService(repository);

        var pointInside = new GeoPoint(15, 15);

        var result = service.FindContainingZones(pointInside);

        Assert.Single(result);
        Assert.Equal("Test Zone", result.First().Name);
    }
}
