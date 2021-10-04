using Travel.Application.Commons.Mappings;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.Queries.ExportTours
{
    public class TourPackageRecord : IMapFrom<TourPackage>
    {
        
        public string Name { get; set; }
        public string MapLocation { get; set; }
    }
}