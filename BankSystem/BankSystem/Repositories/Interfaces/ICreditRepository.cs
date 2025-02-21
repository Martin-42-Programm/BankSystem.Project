namespace BankSystem.Repositories;

public interface ICreditRepository
{
    List<Credit> GetAll();
    List<Credit> GetByUserId(int userId);
    List<Credit> List();
    
    void Add(Credit credit);
    void Update(Credit credit);
    void Delete(Credit credit);
}