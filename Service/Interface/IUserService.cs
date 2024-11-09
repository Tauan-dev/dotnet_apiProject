using ApiProduct.Dto.User;
namespace ApiProduct.Service.Interface
{
    public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> GetUserByIdAsync(int userId);
    Task<UserDTO> CreateUserAsync(CreateUserDTO user);
    Task<bool> UpdateUserAsync(int userId, UpdateUserDTO user);
    Task<bool> DeleteUserAsync(int userId);
}
}
