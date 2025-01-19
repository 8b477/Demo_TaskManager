using DomainLayer.TaskManager.Entities;
using DomainLayer.TaskManager.Interfaces;

using InfrastructureLayer.TaskManager.Context;

using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Repositories
{
    public class TodoStatusRepository : ITodoStatusRepository
    {

        // <--------------------------------> TODO <-------------------------------->
        // 
        // <--------------------------------> **** <-------------------------------->


        #region <-------------> DEPENDENCY <------------->
        private readonly TaskManagerDbContext _context;

        public TodoStatusRepository(TaskManagerDbContext context)
        {
            _context = context;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task AddStatusAsync(TodoStatus status)
        {
            await _context.TodoStatus.AddAsync(status);
            await _context.SaveChangesAsync();
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IEnumerable<TodoStatus>> GetAllStatusesAsync()
        {
            return await _context.TodoStatus.ToListAsync();
        }

        public async Task<TodoStatus?> GetStatusByIdAsync(Guid id)
        {
            return await _context.TodoStatus.FindAsync(id);
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task UpdateStatusAsync(TodoStatus status)
        {
            _context.TodoStatus.Update(status);
            await _context.SaveChangesAsync();
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task DeleteStatusAsync(Guid id)
        {
            var status = await GetStatusByIdAsync(id);
            if (status != null)
            {
                _context.TodoStatus.Remove(status);
                await _context.SaveChangesAsync();
            }
        }
        #endregion



        #region <-------------> TOOLS <------------->

        #endregion

    }
}
