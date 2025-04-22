namespace BankSystem.Services;

public interface IUserService
{
    Task<User> GetUserByIdAsync(string userId);
}