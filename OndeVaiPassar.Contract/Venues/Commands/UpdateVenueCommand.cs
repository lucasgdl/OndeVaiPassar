using MediatR;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Contract.Venues.Commands;

public record UpdateVenueCommand(
    int Id, 
    string Name,
    string City,
    string State,
    string Country,
    string? Address,
    int? Capacity) : IRequest<VenueDto>;
