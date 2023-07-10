using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
{
    public HotelRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}