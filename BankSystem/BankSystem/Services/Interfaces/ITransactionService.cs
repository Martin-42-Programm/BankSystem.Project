namespace BankSystem.Services;

public interface ITransactionService : IGenericService<Transaction, TransactionServiceModel>
{
    //public IQueryable<CardServiceModel> GetAllAsNoTracking();
}