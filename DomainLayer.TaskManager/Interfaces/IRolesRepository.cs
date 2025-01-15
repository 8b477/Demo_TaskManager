
using DomainLayer.TaskManager.Entities;

namespace DomainLayer.TaskManager.Interfaces
{
    public interface IRolesRepository
    {
        /// <summary>
        /// Retrieves all roles.
        /// </summary>
        /// <returns>A collection of all roles.</returns>
        Task<IEnumerable<Roles>> GetAllRolesAsync();

        /// <summary>
        /// Retrieves a role by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the role.</param>
        /// <returns>The role with the specified ID, or null if not found.</returns>
        Task<Roles> GetRoleByIdAsync(Guid id);

        /// <summary>
        /// Adds a new role.
        /// </summary>
        /// <param name="role">The role entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddRoleAsync(Roles role);

        /// <summary>
        /// Updates an existing role.
        /// </summary>
        /// <param name="role">The updated role entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateRoleAsync(Roles role);

        /// <summary>
        /// Deletes a role by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the role to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteRoleAsync(Guid id);
    }
}
