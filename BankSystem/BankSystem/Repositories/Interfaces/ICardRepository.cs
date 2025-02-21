namespace BankSystem.Repositories;

public interface ICardRepository
{
    List<Card> GetAll();
    
    List<Card> GetByUserId(int userId);
    
    List<Card> List();
    
    void Add(Card card);
    void Update(Card card);
    void Delete(Card card);
}