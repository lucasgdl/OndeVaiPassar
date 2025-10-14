using AutoMapper;
using MediatR;
using OndeVaiPassar.Command.Venues.Interfaces;
using OndeVaiPassar.Contract.Venues.Commands;
using OndeVaiPassar.Domain.Entities.Venues;
using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Command.Venues;

public class CreateVenueCommandHandler(IVenueCommandStore venueCommandStore, IMapper mapper) : IRequestHandler<CreateVenueCommand, VenueDto>
{
    private readonly IVenueCommandStore _venueCommandStore = venueCommandStore;
    private readonly IMapper _mapper = mapper;

    public async Task<VenueDto> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
    {
        var venue = VenueEntity.Create(
            request.Name,
            request.City,
            request.State,
            request.Country,
            request.Address,
            request.Capacity);

        await _venueCommandStore.CreateAsync(venue);
        return _mapper.Map<VenueDto>(venue);
    }
}
