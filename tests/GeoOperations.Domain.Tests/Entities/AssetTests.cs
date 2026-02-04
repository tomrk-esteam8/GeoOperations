using GeoOperations.Domain.Entities;
using GeoOperations.Domain.ValueObjects;
using Xunit;

namespace GeoOperations.Domain.Tests.Entities;

public class AssetTests
{
    [Fact]
    public void Should_Create_Asset_With_Valid_Data()
    {
        // Arrange
        var id = Guid.NewGuid();
        var location = new GeoPoint(52.52, 13.405);

        // Act
        var asset = new Asset(id, "Test Asset", location);

        // Assert
        Assert.Equal(id, asset.Id);
        Assert.Equal("Test Asset", asset.Name);
        Assert.Equal(location, asset.Location);
    }

    [Fact]
    public void Should_Throw_When_Name_Is_Null()
    {
        var location = new GeoPoint(0, 0);

        Assert.Throws<ArgumentNullException>(() =>
            new Asset(Guid.NewGuid(), null!, location));
    }

    [Fact]
    public void Should_Throw_When_Location_Is_Null()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new Asset(Guid.NewGuid(), "Asset", null!));
    }
}
