using MediatR;

namespace OndeVaiPassar.Contract.Sports.Commands;

public record DeleteSportCommand(Guid Id) : IRequest;