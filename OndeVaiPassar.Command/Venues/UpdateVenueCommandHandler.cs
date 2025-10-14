using AutoMapper;
using MediatR;
using OndeVaiPassar.Command.Venues.Interfaces;
using OndeVaiPassar.Contract.Venues.Commands;
using OndeVaiPassar.Domain.Interfaces;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Command.Venues;

internal class UpdateVenueCommandHandler(IVenueCommandStore commandStore, IVenueRepository repo, IMapper mapper) : IRequestHandler<UpdateVenueCommand, VenueDto>
{
    private readonly IVenueCommandStore _commandStore = commandStore;
    private readonly IVenueRepository _repo = repo;
    private readonly IMapper _mapper = mapper;

    public async Task<VenueDto> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repo.GetByIdAsync(request.Id);
        if (existing == null) throw new KeyNotFoundException("Venue not found");

        existing.Update(
            request.Name,
            request.City,
            request.State,
            request.Country,
            request.Address,
            request.Capacity);

        await _commandStore.UpdateAsync(existing);
        return _mapper.Map<VenueDto>(existing);
    }
}
