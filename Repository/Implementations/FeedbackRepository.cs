using Contracts.Repositories;
using Entities.Models;

namespace Repository.RepositoryUser;

public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}