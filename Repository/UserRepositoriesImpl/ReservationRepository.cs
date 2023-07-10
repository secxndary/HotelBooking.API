using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
{
    public ReservationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}