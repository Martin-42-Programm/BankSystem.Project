namespace BankSystem.Repositories;

public interface ITransactionRepository
{
    List<Transaction> GetAll();
    Transaction GetById(Guid id);
    void Add(Transaction transaction);
    void Update(Transaction transaction);
    void Delete(Guid id);
}