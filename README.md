# GeoOperations Service

## Overview

GeoOperations is a backend service providing geospatial capabilities such as proximity search, distance calculation, routing abstraction, and zone validation.  
The service is designed with correctness, extensibility, and operational clarity in mind.

## Problem Statement

Many operational systems require accurate geospatial reasoning: determining proximity, validating zones, and calculating distances between assets.  
This service provides a clean, testable backend abstraction for these concerns without coupling domain logic to mapping providers or UI concerns.

## Non-Goals

- Turn-by-turn navigation UI  
- Real-time GPS tracking  
- Full GIS feature set  
- Mobile or frontend integration  

## Architecture

The service follows a **Clean Architecture** approach:

````
API → Application → Domain ← Infrastructure
````

- **Domain**: Pure geospatial concepts and business rules  
- **Application**: Use cases and service orchestration  
- **Infrastructure**: External integrations (DB, routing APIs)  
- **API**: HTTP transport layer only  

## Core Concepts

- **GeoPoint** — immutable latitude/longitude value object  
- **Distance** — strongly-typed distance representation  
- **Asset** — domain entity with spatial location  
- **Zone** — polygon-based operational boundary  

## Key Capabilities

- Proximity search within a given radius  
- Distance calculation using the Haversine formula  
- Zone validation using polygon containment  
- Routing via pluggable provider abstraction  

## Technology Stack

- .NET 6+ / ASP.NET Core  
- NetTopologySuite  
- Entity Framework Core  
- xUnit  
- Swagger / OpenAPI  

## Accuracy vs Performance

- Distance calculations favor correctness over speed  
- Spatial indexing and caching are discussed but not fully implemented  
- External routing providers are abstracted to allow substitution  

## Tradeoffs & Design Decisions

- In-memory persistence used initially for simplicity  
- External routing delegated to provider APIs  
- Clean architecture chosen over vertical slicing for clarity  

## Scaling Considerations

- Spatial indexing via PostGIS  
- Read-heavy endpoints suitable for caching  
- Async I/O throughout the stack  
- API versioning strategy via URL or headers  

## Future Improvements

- PostGIS-backed persistence  
- Distributed caching  
- Batch distance matrix support  
- Rate limiting and observability  