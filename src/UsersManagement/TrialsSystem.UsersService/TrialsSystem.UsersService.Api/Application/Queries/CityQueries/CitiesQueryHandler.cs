using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialSystem.Shared.UsersService.Models;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{
    public class CitiesQueryHandler : IRequestHandler<CitiesQuery, IEnumerable<IdNameDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IdNameDto>> Handle(CitiesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<IdNameDto>>(await _cityRepository.GetAsync());
        }
    }
}
