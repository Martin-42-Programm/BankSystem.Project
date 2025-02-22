namespace BankSystem.Repositories;

public interface IOfficeRepository
{
    List<Office> GetAll();
    List<Office> GetOfficesByUserId(int userId);
    Office GetOffice(Guid officeId);
    
    void Add(Office office);
    void Update(Office office);
    void Delete(Office office);
}