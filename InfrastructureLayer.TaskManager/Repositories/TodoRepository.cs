using DomainLayer.TaskManager.Entities;
using DomainLayer.TaskManager.Interfaces;
using InfrastructureLayer.TaskManager.Context;

using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Repositories
{
    public class TodoRepository : ITodosRepository
    {
        // <--------------------------------> TODO <-------------------------------->
        // 
        // <--------------------------------> **** <-------------------------------->


        #region <-------------> DEPENDENCY <------------->
        private readonly TaskManagerDbContext _context;

        public TodoRepository(TaskManagerDbContext context)
        {
            _context = context;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task AddTodoAsync(Todos todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IEnumerable<Todos>> GetAllTodosAsync()
        {
            return await _context.Todos.Include(t => t.User).Include(t => t.Status).ToListAsync();
        }

        public async Task<Todos?> GetTodoByIdAsync(Guid id)
        {
            return await _context.Todos.Include(t => t.User).Include(t => t.Status).FirstOrDefaultAsync(t => t.Id_Todo == id);
        }

        public async Task<IEnumerable<Todos>> GetTodosByUserIdAsync(Guid userId)
        {
            return await _context.Todos
                                 .Where(todo => todo.FK_User == userId)
                                 .ToListAsync();
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task UpdateTodoAsync(Todos todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task DeleteTodoAsync(Guid id)
        {
            var todo = await GetTodoByIdAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
        #endregion



        #region <-------------> TOOLS <------------->

        #endregion

    }
}
