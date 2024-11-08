using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Data;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Método para obter todos os usuários e retornar como UserDTO
    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        return await _dbContext.Users
            .Include(u => u.Contatcs) // Inclui contatos na consulta
            .Include(u => u.Orders) // Inclui pedidos na consulta
            .Select(user => new UserDTO
            {
                UserId = user.UserId ?? 0,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                ContactIds = user.Contatcs.Select(c => c.ContactId ?? 0).ToList(),
                OrderIds = user.Orders.Select(o => o.OrderId ?? 0).ToList()
            })
            .ToListAsync();
    }

    // Método para obter um usuário específico pelo ID e retornar como UserDTO
    public async Task<UserDTO> GetUserByIdAsync(int userId)
    {
        var user = await _dbContext.Users
            .Include(u => u.Contatcs)
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.UserId == userId);
        
        if (user == null)
        {
            throw new KeyNotFoundException("Não foi possível encontrar o usuário");
        }

        return new UserDTO
        {
            UserId = user.UserId ?? 0,
            Name = user.Name,
            Birthdate = user.Birthdate,
            Email = user.Email,
            ContactIds = user.Contatcs.Select(c => c.ContactId ?? 0).ToList(),
            OrderIds = user.Orders.Select(o => o.OrderId ?? 0).ToList()
        };
    }

    // Método para criar um novo usuário usando CreateUserDTO
    public async Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDto)
    {
        var user = new User
        {
            Name = createUserDto.Name,
            Birthdate = createUserDto.Birthdate,
            Email = createUserDto.Email
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return new UserDTO
        {
            UserId = user.UserId ?? 0,
            Name = user.Name,
            Birthdate = user.Birthdate,
            Email = user.Email,
            ContactIds = new List<int>(), // Inicialmente sem contatos
            OrderIds = new List<int>() // Inicialmente sem pedidos
        };
    }

    // Método para atualizar um usuário usando UpdateUserDTO
    public async Task<bool> UpdateUserAsync(int userId, UpdateUserDTO updateUserDto)
    {
        var existingUser = await _dbContext.Users.FindAsync(userId);
        if (existingUser == null)
        {
            throw new KeyNotFoundException("O Id do usuário não foi encontrado");
        }

        existingUser.Name = updateUserDto.Name;
        existingUser.Birthdate = updateUserDto.Birthdate;
        existingUser.Email = updateUserDto.Email;

        _dbContext.Entry(existingUser).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Método para deletar um usuário
    public async Task<bool> DeleteUserAsync(int userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            throw new KeyNotFoundException("Usuário não existe");
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
