using GeoOperations.Application.Services;
using GeoOperations.Domain.ValueObjects;
using Xunit;

namespace GeoOperations.Application.Tests.Services;

public class HaversineDistanceCalculatorTests
{
    [Fact]
    public void Should_Return_Zero_When_Points_Are_Identical()
    {
        var calculator = new HaversineDistanceCalculator();
        var point = new GeoPoint(52.52, 13.405);

        var distance = calculator.Calculate(point, point);

        Assert.Equal(0, distance.Meters);
    }

    [Fact]
    public void Should_Calculate_Distance_Between_Berlin_And_Paris()
    {
        var calculator = new HaversineDistanceCalculator();

        var berlin = new GeoPoint(52.5200, 13.4050);
        var paris = new GeoPoint(48.8566, 2.3522);

        var distance = calculator.Calculate(berlin, paris);

        // Approx. 878 km (allow tolerance)
        Assert.InRange(
            distance.ToKilometers(),
            870,
            890);
    }

    [Fact]
    public void Distance_Should_Be_Symmetric()
    {
        var calculator = new HaversineDistanceCalculator();

        var a = new GeoPoint(52.52, 13.405);
        var b = new GeoPoint(48.8566, 2.3522);

        var ab = calculator.Calculate(a, b).Meters;
        var ba = calculator.Calculate(b, a).Meters;

        Assert.InRange(Math.Abs(ab - ba), 0, 0.001);
    }

    [Fact]
    public void Should_Handle_Very_Close_Points()
    {
        var calculator = new HaversineDistanceCalculator();

        var a = new GeoPoint(52.5200, 13.4050);
        var b = new GeoPoint(52.5201, 13.4051);

        var distance = calculator.Calculate(a, b);

        Assert.InRange(distance.Meters, 0, 50);
    }
}
