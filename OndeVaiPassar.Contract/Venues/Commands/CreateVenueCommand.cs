using MediatR;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Contract.Venues.Commands;

public record CreateVenueCommand(
    string Name,
    string City,
    string State,
    string Country,
    string? Address,
    int? Capacity) : IRequest<VenueDto>;
