using DomainLayer.TaskManager.Entities;
using DomainLayer.TaskManager.Interfaces;

using InfrastructureLayer.TaskManager.Context;

using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.TaskManager.Repositories
{
    public class TodoRepository : ITodosRepository
    {
        private readonly TaskManagerDbContext _context;

        public TodoRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todos>> GetAllTodosAsync()
        {
            return await _context.Todos.Include(t => t.User).Include(t => t.Status).ToListAsync();
        }

        public async Task<Todos?> GetTodoByIdAsync(Guid id)
        {
            return await _context.Todos.Include(t => t.User).Include(t => t.Status).FirstOrDefaultAsync(t => t.Id_Todo == id);
        }

        public async Task AddTodoAsync(Todos todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(Todos todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(Guid id)
        {
            var todo = await GetTodoByIdAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Todos>> GetTodosByUserIdAsync(Guid userId)
        {
            return await _context.Todos
                                 .Where(todo => todo.FK_User == userId)
                                 .ToListAsync();
        }

    }
}
