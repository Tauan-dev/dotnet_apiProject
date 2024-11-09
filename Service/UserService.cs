using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiProduct.Data;
using ApiProduct.Service.Interface;
using ApiProduct.Dto.User;
using ApiProduct.Dto.Contact;
using ApiProduct.Dto.Order;
using ApiProduct.Models;

namespace ApiProduct.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users
             .Include(u => u.Contacts)
             .Include(u => u.Orders)
             .ThenInclude(o => o.Products)
             .ToListAsync();

            return users.Select(user => new UserDTO
            {
                UserId = user.UserId ?? 0,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Contacts = user.Contacts?.Select(c => new ContactDTO
                {
                    ContactId = c.ContactId ?? 0,
                    Type = c.Type,
                    Number = c.Number,
                    IdUser = c.IdUser ?? 0
                }).ToList(),
                Orders = user.Orders?.Select(o => new OrderDTO
                {
                    OrderId = o.OrderId ?? 0,
                    Status = o.Status,
                    Quantity = o.Quantity,
                    IdUser = o.IdUser ?? 0,
                    ProductIds = o.Products?.Select(p => p.ProductId ?? 0).ToList()
                }).ToList(),
            })
                .ToList();
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext.Users
            .Include(u => u.Contacts)
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            return new UserDTO
            {
                UserId = user.UserId ?? 0,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Contacts = user.Contacts?.Select(c => new ContactDTO
                {
                    ContactId = c.ContactId ?? 0,
                    Type = c.Type,
                    Number = c.Number,
                    IdUser = c.IdUser ?? 0
                }).ToList(),
                Orders = user.Orders?.Select(o => new OrderDTO
                {
                    OrderId = o.OrderId ?? 0,
                    Status = o.Status,
                    Quantity = o.Quantity,
                    IdUser = o.IdUser ?? 0,
                    ProductIds = o.Products?.Select(p => p.ProductId ?? 0).ToList() // Lista de IDs de produtos
                }).ToList()
            };

        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Birthdate = userDto.Birthdate,
                Email = userDto.Email
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return new UserDTO
            {
                UserId = user.UserId ?? 0,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Email = user.Email
            };
        }

        public async Task<bool> UpdateUserAsync(int userId, UpdateUserDTO userDto)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            user.Name = userDto.Name;
            user.Birthdate = userDto.Birthdate;
            user.Email = userDto.Email;

            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
