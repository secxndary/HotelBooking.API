using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}