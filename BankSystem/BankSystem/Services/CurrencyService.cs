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
        return this.InternalGetAll().Select(entity => entity.ToModel());
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

    public Task<CurrencyServiceModel> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    private IQueryable<Currency> InternalGetAll()
    {
        return _repository.GetAll();
    }
}