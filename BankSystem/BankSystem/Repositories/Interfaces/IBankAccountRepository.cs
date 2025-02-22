namespace BankSystem.Repositories;

public interface IBankAccountRepository
{
    void Add(BankAccount bankAccount);
    void Update(BankAccount bankAccount);
    void Delete(BankAccount bankAccount);

    IQueryable<BankAccountServiceModel> GetAll();
    
    BankAccount GetById(Guid id);
}