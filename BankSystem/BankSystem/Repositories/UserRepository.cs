namespace BankSystem.Repositories;

public class UserRepository
{
   protected readonly ProjectDbContext _context;

   public UserRepository(ProjectDbContext context)
   {
       _context = context;
   }
    public async Task<User> GetUserByIdAsync(string id)
    {
        return await _context.Users.FirstOrDefaultAsync(t => t.Id == id);
    }
    
}
