using MediatR;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Contract.Sports.Command;

public record CreateSportCommand(string Name, string LogoUrl) : IRequest<SportDto>;