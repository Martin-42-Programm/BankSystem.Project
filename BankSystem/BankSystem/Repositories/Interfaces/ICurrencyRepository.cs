namespace BankSystem.Repositories;

public interface ICurrencyRepository
{
    List<Currency> GetAll();
    Currency GetById(long id);
    Currency GetByName(string name);
    
    void Add(Currency currency);
    void Update(Currency currency);
    void Delete(Currency currency);
    
}