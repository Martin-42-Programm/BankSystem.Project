namespace BankSystem.Services;

public class TransactionService : ITransactionService
{
    private readonly TransactionRepository _transactionRepository;

    public TransactionService(TransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public IQueryable<TransactionServiceModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public TransactionServiceModel GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionServiceModel> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<TransactionServiceModel> AddAsync(TransactionServiceModel model)
    {
        if (model == null)
            return new TransactionServiceModel();
        await _transactionRepository.CreateAsync(model.ToEntity());
        return model;
    }

    public Task<TransactionServiceModel> UpdateAsync(TransactionServiceModel model)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionServiceModel> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}