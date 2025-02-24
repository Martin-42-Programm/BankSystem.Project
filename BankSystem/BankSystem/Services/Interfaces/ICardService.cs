namespace BankSystem.Services;

public interface ICardService : IGenericService<Card, CardServiceModel>
{
    public IQueryable<CardServiceModel> GetAllAsNoTracking();
}