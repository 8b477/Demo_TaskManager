
using DomainLayer.TaskManager.Entities;

namespace DomainLayer.TaskManager.Interfaces
{
    public interface IUsersRepository
    {

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A collection of all users.</returns>
        Task<IEnumerable<Users>> GetAllUsersAsync();

        /// <summary>
        /// Retrieves a specific user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The user that matches the provided ID, or null if not found.</returns>
        Task<Users?> GetUserByIdAsync(Guid id);

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Users> AddUserAsync(Users user);

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="user">The updated user entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Users> UpdateUserAsync(Users user);

        /// <summary>
        /// Deletes a user from the database by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<bool> DeleteUserAsync(Guid id);

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user entity that matches the provided email, or null if not found.</returns>
        Task<Users> GetUserByEmailAsync(string email);

        /// <summary>
        /// Retrieves all tasks (Todos) associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A collection of tasks associated with the specified user.</returns>
        Task<IEnumerable<Todos>?> GetTodosByUserIdAsync(Guid userId);
    }
}
