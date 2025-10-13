using AutoMapper;
using MediatR;
using OndeVaiPassar.Contract.Sports.Command;
using OndeVaiPassar.Domain.Entities.Sports;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Command.Sports;

public class CreateSportCommandHandler : IRequestHandler<CreateSportCommand, SportDto>
{
    private readonly ISportCommandStore _sportCommandStore;
    private readonly IMapper _mapper;

    public CreateSportCommandHandler(ISportCommandStore sportCommandStore, IMapper mapper)
    {
        _sportCommandStore = sportCommandStore;
        _mapper = mapper;
    }

    public async Task<SportDto> Handle(CreateSportCommand request, CancellationToken cancellationToken)
    {
        var sport = SportEntity.Create(request.Name, request.LogoUrl);
        await _sportCommandStore.CreateAsync(sport);
        return _mapper.Map<SportDto>(sport);
    }
}
