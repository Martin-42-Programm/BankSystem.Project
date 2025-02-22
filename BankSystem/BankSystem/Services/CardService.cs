namespace BankSystem.Services;

public class CardService : ICardService
{
    public IQueryable<CardServiceModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public CardServiceModel GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<CardServiceModel> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<CardServiceModel> AddAsync(CardServiceModel model)
    {
        throw new NotImplementedException();
    }

    public Task<CardServiceModel> UpdateAsync(CardServiceModel model)
    {
        throw new NotImplementedException();
    }

    public void DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}