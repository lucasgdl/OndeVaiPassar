using MediatR;

namespace OndeVaiPassar.Contract.Venues.Commands;

public record DeleteVenueCommand(Guid Id) : IRequest;
