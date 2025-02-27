namespace BankSystem.Services;

public class CreditService : ICreditService
{
    public IQueryable<CreditServiceModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public CreditServiceModel GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<CreditServiceModel> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<CreditServiceModel> AddAsync(CreditServiceModel model)
    {
        throw new NotImplementedException("ceco bate");
    }

    public Task<CreditServiceModel> UpdateAsync(CreditServiceModel model)
    {
        throw new NotImplementedException();
    }

    public Task<CreditServiceModel> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}