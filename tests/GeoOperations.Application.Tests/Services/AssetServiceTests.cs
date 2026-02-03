using GeoOperations.Application.Services;
using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;
using Xunit;

namespace GeoOperations.Application.Tests.Services;

public class AssetServiceTests
{
    [Fact]
    public void FindNearby_Should_Filter_And_Order_Assets_By_Distance()
    {
        // Arrange
        var berlin = new GeoPoint(52.5200, 13.4050);

        var assets = new[]
        {
            new Asset(
                Guid.NewGuid(),
                "Berlin Asset",
                new GeoPoint(52.5200, 13.4050)),

            new Asset(
                Guid.NewGuid(),
                "Munich Asset",
                new GeoPoint(48.1351, 11.5820)),

            new Asset(
                Guid.NewGuid(),
                "New York Asset",
                new GeoPoint(40.7128, -74.0060))
        };

        var repository = new FakeAssetRepository(assets);
        var distanceCalculator = new HaversineDistanceCalculator();

        var service = new AssetService(repository, distanceCalculator);

        // Act
        var results = service.FindNearby(
            berlin,
            Distance.FromKilometers(1000));

        // Assert
        Assert.Equal(2, results.Count);

        var orderedResults = results.ToList();

        Assert.Equal("Berlin Asset", orderedResults[0].Name);
        Assert.Equal("Munich Asset", orderedResults[1].Name);

        Assert.True(
            orderedResults[0].Distance.Meters <= orderedResults[1].Distance.Meters);
    }
}
