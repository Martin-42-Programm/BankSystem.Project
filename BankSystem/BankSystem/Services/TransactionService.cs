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
        return this.InternalGetAll().Select(c => c.ToModel());
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
       
        await _transactionRepository.CreateAsync(model.ToEntity());
        return model;
    }

    public async Task<TransactionServiceModel> UpdateAsync(TransactionServiceModel model)
    {
            var updatedEntity = await InternalUpdateAsync(model);
            return updatedEntity.ToModel();
        
    }

    public Task<TransactionServiceModel> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
    
    private IQueryable<Transaction> InternalGetAll()
    {
        return _transactionRepository.GetAll();
    }
    
    private async Task<Transaction> InternalUpdateAsync(TransactionServiceModel model)
    {
        return await _transactionRepository.EditAsync(model.ToEntity());
    }
}