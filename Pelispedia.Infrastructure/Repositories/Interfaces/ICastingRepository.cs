using Pelispedia.Domain.DbEntities;

namespace Pelispedia.Infrastructure.Repositories.Interfaces
{
    public interface ICastingRepository
    {
        Task InsertCasting(Casting casting);
    }
}