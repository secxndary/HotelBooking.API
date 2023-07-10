using Contracts;
using Contracts.Repository;
using Service.Contracts;
namespace Service;

public sealed class FeedbackService : IFeedbackService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public FeedbackService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

}