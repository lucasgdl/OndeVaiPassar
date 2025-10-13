using MediatR;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Contract.Sports.Queries;

public record ListSportsQuery(int Page = 1, int PageSize = 20) : IRequest<IEnumerable<SportDto>>;