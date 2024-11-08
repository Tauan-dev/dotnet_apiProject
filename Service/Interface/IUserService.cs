public interface IUserService {
    Task<IEnumerable<User>> GetAllUSersAsync();
    Task<User> GetUserByIdAsync(int userId);
    Task<User> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(int userId, User user);
    Task<bool> DeleteUserAsync(int userId);
}