using BankSystem.Models;
using BankSystem.ServiceModels;

namespace BankSystem.Services;

public class BankAccountService : IBankAccountService

{
    private readonly BankAccountRepository _repository;

    public BankAccountService(BankAccountRepository repository)
    {
        this._repository = repository;
    }
    
    public async Task<BankAccountServiceModel> GetByIdAsync(string id)
    {
        return (await this._repository.GetAll()
            .Include(c => c.CreatedBy)
            .Include(c => c.ModifiedBy)
            .Include(c => c.DeletedBy)
            .SingleOrDefaultAsync(c => c.Id == Guid.Parse(id)))?
            .ToModel() ?? new BankAccountServiceModel();


    }
    public IQueryable<BankAccountServiceModel> GetAll()
    {
        return this.InternalGetAll().Select(c => c.ToModel());
    }

    public async Task<BankAccountServiceModel> AddAsync(BankAccountServiceModel model)
    {
        if (model == null)
            return new BankAccountServiceModel();
        await _repository.CreateAsync(model.ToEntity());
        return model;
    }

    public async Task<BankAccountServiceModel> UpdateAsync(BankAccountServiceModel model)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteAsync(string id)
    {
        throw new System.NotImplementedException();
    }
    public BankAccountServiceModel GetById(object id)
    {
        return _repository.GetById((Guid)id).ToModel();
    }
    
    private IQueryable<BankAccount> InternalGetAll()
    {
        return this._repository.GetAll();
        // .Include(r => r.CreatedBy)
        // .Include(r => r.ModifiedBy)
        // .Include(r => r.DeletedBy);
    }

   
}