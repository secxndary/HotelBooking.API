using Contracts.Repository;
using Entities.Models;

namespace Repository.RepositoryUser;

public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
{
    public HotelRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}