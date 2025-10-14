using MediatR;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Contract.Sports.Commands;

public record CreateSportCommand(string Name, string LogoUrl) : IRequest<SportDto>;