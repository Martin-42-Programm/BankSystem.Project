using BankSystem.Data.Entities;

namespace BankSystem.Repositories;

public class BankAccountRepository : MetadataBaseGenericRepository<BankAccount>
{
    //private readonly ProjectDbContext _context;
    
    public BankAccountRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,
        httpContextAccessor)
    {
        
    }
    //public AccountRepository(ProjectDbContext context) => _context = context;
    
    /*public void Add(Account entity)
    {
         this.Context.Accounts.Add(entity);
         this.Context.SaveChanges();
        
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

    public IQueryable<Account> GetAll()
    {
        //TODO: Sorting the lists
        //TODO: IEnumerable
        return this._context.Accounts.ToList().AsQueryable();
    }

    

*/





}