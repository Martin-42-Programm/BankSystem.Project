using Microsoft.EntityFrameworkCore;

namespace BankSystem.Services;

public class AccountService<Account, AccountServiceModel> : IGenericService<Account, AccountServiceModel>
{
    private readonly AccountRepository repository;

    public AccountService(AccountRepository repository)
    {
        this.repository = repository;
    }
    
    public async Task<AccountServiceModel> GetByIdAsync(string id)
    {
        throw new System.NotImplementedException();


    }



    public IQueryable<AccountServiceModel> GetAll()
    {
        throw new System.NotImplementedException();
    }

    public async Task<AccountServiceModel> AddAsync(AccountServiceModel model)
    {
        throw new System.NotImplementedException();
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