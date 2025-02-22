namespace BankSystem.Services;

public class CurrencyService : ICurrencyService
{
    
    private readonly CurrencyRepository _repository;

    public CurrencyService(CurrencyRepository repository)
    {
        this._repository = repository;
    }

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

    public async Task<CurrencyServiceModel> AddAsync(CurrencyServiceModel model)
    {
        if (model == null)
            return new CurrencyServiceModel();
        await _repository.CreateAsync(model.ToEntity());
        
        return model;
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