namespace BankSystem.Services;

public class TransactionService : ITransactionService
{
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

    public Task<TransactionServiceModel> AddAsync(TransactionServiceModel model)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionServiceModel> UpdateAsync(TransactionServiceModel model)
    {
        throw new NotImplementedException();
    }

    public void DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}