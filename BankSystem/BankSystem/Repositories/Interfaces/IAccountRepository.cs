namespace BankSystem.Repositories;

public interface IAccountRepository
{
    void Add(Account account);
    void Update(Account account);
    void Delete(Account account);

    IQueryable<Account> GetAll();
    
    Account GetById(Guid id);
}