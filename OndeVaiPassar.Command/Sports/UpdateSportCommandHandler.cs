using AutoMapper;
using MediatR;
using OndeVaiPassar.Contract.Sports.Commands;
using OndeVaiPassar.Domain.Interfaces;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Command.Sports;

public class UpdateSportCommandHandler : IRequestHandler<UpdateSportCommand, SportDto>
{
    private readonly ISportCommandStore _commandStore;
    private readonly ISportRepository _repo;
    private readonly IMapper _mapper;

    public UpdateSportCommandHandler(ISportCommandStore commandStore, ISportRepository repo, IMapper mapper)
    {
        _commandStore = commandStore;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<SportDto> Handle(UpdateSportCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repo.GetByIdAsync(request.Id);
        if (existing == null) throw new KeyNotFoundException("Sport not found");

        existing.Update(request.Name, request.LogoUrl);
        await _commandStore.UpdateAsync(existing);
        return _mapper.Map<SportDto>(existing);
    }
}
