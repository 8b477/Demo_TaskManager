

using DomainLayer.TaskManager.Entities;

namespace DomainLayer.TaskManager.Interfaces
{
    public interface ITodoStatusRepository
    {
        /// <summary>
        /// Retrieves all todo statuses.
        /// </summary>
        /// <returns>A collection of all todo statuses.</returns>
        Task<IEnumerable<TodoStatus>> GetAllStatusesAsync();

        /// <summary>
        /// Retrieves a specific todo status by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the todo status.</param>
        /// <returns>The todo status with the specified ID, or null if not found.</returns>
        Task<TodoStatus?> GetStatusByIdAsync(Guid id);

        /// <summary>
        /// Adds a new todo status.
        /// </summary>
        /// <param name="status">The todo status entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddStatusAsync(TodoStatus status);

        /// <summary>
        /// Updates an existing todo status.
        /// </summary>
        /// <param name="status">The updated todo status entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateStatusAsync(TodoStatus status);

        /// <summary>
        /// Deletes a todo status by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the todo status to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteStatusAsync(Guid id);
    }
}
