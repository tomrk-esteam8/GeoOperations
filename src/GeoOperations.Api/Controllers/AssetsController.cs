using GeoOperations.Api.DTOs;
using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace GeoOperations.Api.Controllers;

[ApiController]
[Route("api/assets")]
public sealed class AssetsController : ControllerBase
{
    private readonly IAssetService _assetService;

    public AssetsController(IAssetService assetService)
    {
        _assetService = assetService;
    }

    [HttpGet("nearby")]
    public IActionResult GetNearby(
        [FromQuery] double lat,
        [FromQuery] double lon,
        [FromQuery] double radiusKm)
    {
        if (radiusKm <= 0)
            return BadRequest("Radius must be positive.");

        var origin = new GeoPoint(lat, lon);
        var radius = Distance.FromKilometers(radiusKm);

        var results = _assetService.FindNearby(origin, radius);

        var response = results.Select(r =>
            new NearbyAssetResponse(
                r.AssetId,
                r.Name,
                r.Distance.ToKilometers()));

        return Ok(response);
    }
}
