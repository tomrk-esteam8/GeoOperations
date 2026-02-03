using GeoOperations.Application.Interfaces;
using GeoOperations.Application.Services;
using GeoOperations.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IGeoDistanceCalculator, HaversineDistanceCalculator>();
builder.Services.AddSingleton<IAssetRepository, InMemoryAssetRepository>();
builder.Services.AddSingleton<IAssetService, AssetService>();

builder.Services.AddSingleton<IZoneRepository, InMemoryZoneRepository>();
builder.Services.AddSingleton<IZoneService, ZoneService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
