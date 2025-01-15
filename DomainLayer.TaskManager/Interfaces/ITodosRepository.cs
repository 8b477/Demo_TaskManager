using DomainLayer.TaskManager.Entities;

namespace DomainLayer.TaskManager.Interfaces
{
    public interface ITodosRepository
    {
        /// <summary>
        /// Retrieves all tasks (todos).
        /// </summary>
        /// <returns>A collection of all tasks.</returns>
        Task<IEnumerable<Todos>> GetAllTodosAsync();

        /// <summary>
        /// Retrieves a specific task (todo) by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the task.</param>
        /// <returns>The task with the specified ID, or null if not found.</returns>
        Task<Todos?> GetTodoByIdAsync(Guid id);

        /// <summary>
        /// Adds a new task (todo).
        /// </summary>
        /// <param name="todo">The task entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddTodoAsync(Todos todo);

        /// <summary>
        /// Updates an existing task (todo).
        /// </summary>
        /// <param name="todo">The updated task entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateTodoAsync(Todos todo);

        /// <summary>
        /// Deletes a task (todo) by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the task to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteTodoAsync(Guid id);

        /// <summary>
        /// Retrieves tasks (todos) associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A collection of tasks associated with the specified user.</returns>
        Task<IEnumerable<Todos>> GetTodosByUserIdAsync(Guid userId);
    }
}
