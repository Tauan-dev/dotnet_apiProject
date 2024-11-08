namespace ApiProduct.Service.Interface
{
    public interface IUserService {
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int userId);
    Task<User> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(int userId, User user);
    Task<bool> DeleteUserAsync(int userId);
}
}

