using BankSystem.Models;
using BankSystem.ServiceModels;

namespace BankSystem.Services;

public class AccountService : IAccountService

{
    private readonly AccountRepository _repository;

    public AccountService(AccountRepository repository)
    {
        this._repository = repository;
    }
    
    public async Task<AccountServiceModel> GetByIdAsync(string id)
    {
        return (await this._repository.GetAll()
            .Include(c => c.CreatedBy)
            .Include(c => c.ModifiedBy)
            .Include(c => c.DeletedBy)
            .SingleOrDefaultAsync(c => c.Id == Guid.Parse(id)))?
            .ToModel() ?? new AccountServiceModel();


    }



    public IQueryable<AccountServiceModel> GetAll()
    {
        throw new System.NotImplementedException();
    }

    public async Task<AccountServiceModel> AddAsync(AccountServiceModel model)
    {
        if (model == null)
            return new AccountServiceModel();
        //await _repository.CreateAsync(model.ToEntity());
        return model;
    }

    public async Task<AccountServiceModel> UpdateAsync(AccountServiceModel model)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteAsync(string id)
    {
        throw new System.NotImplementedException();
    }
}