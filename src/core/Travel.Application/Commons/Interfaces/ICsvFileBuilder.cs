using System.Collections.Generic;
using Travel.Application.TourLists.Queries.ExportTours;
using Travel.Domain.Entities;

namespace Travel.Application.Commons.Interfaces
{
    public interface ICsvFileBuilder
    {
       
        byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records);
    }
}