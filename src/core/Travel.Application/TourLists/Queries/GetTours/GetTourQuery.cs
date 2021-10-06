using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Travel.Application.Commons.Interfaces;
using Travel.Application.Dtos;

namespace Travel.Application.TourLists.Queries.GetTours
{
    public class GetTourQuery : IRequest<ToursVm>
    {

        public class GetToursQueryHandler : IRequestHandler<GetTourQuery, ToursVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetToursQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ToursVm> Handle(GetTourQuery request, CancellationToken cancellationToken)
            {
                return new ToursVm
                {
                    Lists = await _context.TourLists
                        .ProjectTo<TourListDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.City)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}