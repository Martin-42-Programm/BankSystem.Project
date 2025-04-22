namespace BankSystem.Services.NotificationServices;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;

    public async Task<User> GetUserByIdAsync(string userId)
    {
        return await _userRepository.GetUserByIdAsync(userId);
    }
}