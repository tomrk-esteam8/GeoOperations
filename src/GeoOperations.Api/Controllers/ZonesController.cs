using GeoOperations.Api.DTOs;
using GeoOperations.Application.Interfaces;
using GeoOperations.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace GeoOperations.Api.Controllers;

[ApiController]
[Route("api/zones")]
public sealed class ZonesController : ControllerBase
{
    private readonly IZoneService _zoneService;

    public ZonesController(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }

    [HttpGet("check")]
    public IActionResult Check(
        [FromQuery] double lat,
        [FromQuery] double lon)
    {
        var point = new GeoPoint(lat, lon);

        var zones = _zoneService.FindContainingZones(point);

        var response = zones.Select(z =>
            new ZoneCheckResponse(z.Id, z.Name));

        return Ok(response);
    }
}
