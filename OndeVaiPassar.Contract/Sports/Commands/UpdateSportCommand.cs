using MediatR;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Contract.Sports.Commands;

public record UpdateSportCommand(Guid Id, string Name, string LogoUrl) : IRequest<SportDto>;
