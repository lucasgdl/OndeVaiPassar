using MediatR;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Contract.Sports.Queries;

public record GetSportByIdQuery(Guid Id) : IRequest<SportDto?>;