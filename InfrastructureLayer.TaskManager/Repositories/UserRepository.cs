using DomainLayer.TaskManager.Entities;
using DomainLayer.TaskManager.Interfaces;

using InfrastructureLayer.TaskManager.Context;
using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly TaskManagerDbContext _context;

        public UserRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<Users?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id_User == id);
        }

        public async Task AddUserAsync(Users user)
        {
            var defaultRole = await _context.Roles.FirstOrDefaultAsync(x => x.RoleName == "User")
                              ?? throw new ArgumentNullException();

            user.Role = defaultRole;

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Users?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Todos>> GetTodosByUserIdAsync(Guid userId)
        {
            return await _context.Todos
                .Where(t => t.FK_User == userId)
                .Include(t => t.Status)
                .ToListAsync();
        }
    }
}
