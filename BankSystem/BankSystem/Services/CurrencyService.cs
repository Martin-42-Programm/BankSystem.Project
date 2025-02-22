namespace BankSystem.Services;

public class CurrencyService : ICurrencyService
{
    public IQueryable<CurrencyServiceModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public CurrencyServiceModel GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyServiceModel> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyServiceModel> AddAsync(CurrencyServiceModel model)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyServiceModel> UpdateAsync(CurrencyServiceModel model)
    {
        throw new NotImplementedException();
    }

    public void DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}