using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travel.Domain.Entities;

namespace Travel.Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TourList> TourLists { get; set; }
        DbSet<TourPackage> TourPackages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}