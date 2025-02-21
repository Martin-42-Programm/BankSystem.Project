using BankSystem.Data.Entities;

namespace BankSystem.Repositories;

public class AccountRepository : MetadataBaseGenericRepository<Account>
{
    public AccountRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,
        httpContextAccessor)
    {
        
    }
    
    /*public AccountRepository(ProjectDbContext context) => _context = context;
    
    public void Add(Account entity)
    {
         this._context.Accounts.Add(entity);
         this._context.SaveChanges();
        
    }

    public void Update(Account entity)
    {
        //TODO: clear this case
        this._context.Accounts.Update(entity);
    }

    public void Delete(Account entity)
    {
        this._context.Accounts.Remove(entity);
    }

    public Account GetById(Guid id)
    {
        return this._context.Accounts.Find(id);
    }

    public List<Account> GetAll()
    {
        //TODO: Sorting the lists
        //TODO: IEnumerable
        return this._context.Accounts.ToList();
    }

    


*/




}