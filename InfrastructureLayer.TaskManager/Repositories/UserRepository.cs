using DomainLayer.TaskManager.Entities;
using DomainLayer.TaskManager.Interfaces;
using InfrastructureLayer.TaskManager.Context;
using InfrastructureLayer.TaskManager.Enums;
using InfrastructureLayer.TaskManager.Exceptions;

using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.TaskManager.Repositories
{
    public class UserRepository : IUsersRepository
    {

        // <--------------------------------> TODO <-------------------------------->
        // 
        // <--------------------------------> **** <-------------------------------->


        #region <-------------> DEPENDENCY <------------->
        private readonly TaskManagerDbContext _context;
        private readonly IRolesRepository _roleRepo;
        public UserRepository(TaskManagerDbContext context, IRolesRepository roleRepo)
        {
            _context = context;
            _roleRepo = roleRepo;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<Users> AddUserAsync(Users user)
        {
            try
            {
                bool existingMail = await CheckMailAlreadyExist(user.Email);

                if (existingMail)
                    throw new InfrastructureException(
                        "The mail is not correct",
                        InfrastructureErrorCode.UserAlreadyExists);


                var defaultRole = await _roleRepo.GetDefaultUserRole();

                if (defaultRole is null)
                    throw new InfrastructureException(
                        $"The default role is not found",
                        InfrastructureErrorCode.RoleNotFound);

                user.Role = defaultRole;


                var userAdded = await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();

                return userAdded.Entity;
            }
            catch (DbUpdateException ex)
            {
                throw new InfrastructureException(
                    ex.Message,
                    InfrastructureErrorCode.DatabaseError
                );
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(
                    $"An unexpected error occurred: {ex.Message}",
                    InfrastructureErrorCode.UnexpectedError);
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users
                                     .Include(u => u.Role)
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(
                    $"An unexpected error occurred: {ex.Message}",
                    InfrastructureErrorCode.UnexpectedError
                );
            }
        }

        public async Task<Users?> GetUserByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Users
                                           .Include(u => u.Role)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(u => u.Id_User == id);

                if (result is null)
                    throw new InfrastructureException(
                                $"No correspondence with the data provided",
                                InfrastructureErrorCode.InvalidUserData);

                return result;
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(
                    $"An unexpected error occurred: {ex.Message}",
                    InfrastructureErrorCode.UnexpectedError);
            }
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            try
            {
                var result = await _context.Users
                                           .Include(u => u.Role)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(u => u.Email == email);

                if (result is null)
                    throw new InfrastructureException(
                        "The email provided has not been matched",
                        InfrastructureErrorCode.InvalidUserData);

                return result;
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(
                    $"An unexpected error occurred: {ex.Message}",
                    InfrastructureErrorCode.UnexpectedError);
            }
        }

        public async Task<IEnumerable<Todos>?> GetTodosByUserIdAsync(Guid userId)
        {
            try
            {
                return await _context.Todos
                                           .Where(t => t.FK_User == userId)
                                           .Include(t => t.Status)
                                           .AsNoTracking()
                                           .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new InfrastructureException(
                    $"An unexpected error occurred: {ex.Message}",
                    InfrastructureErrorCode.UnexpectedError);
            }
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<Users> UpdateUserAsync(Users user)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(x => x.Id_User == user.Id_User);

                if (existingUser is null)
                    throw new InfrastructureException(
                        "The identifier provided has not been matched",
                        InfrastructureErrorCode.InvalidUserData);

                var userUpdated = _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();

                return userUpdated.Entity;
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(
                    $"An unexpected error occurred: {ex.Message}",
                    InfrastructureErrorCode.UnexpectedError);
            }
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            try
            {
                var existingUser = await GetUserByIdAsync(id);

                if (existingUser is null)
                    throw new InfrastructureException(
                        "The identifier provided has not been matched",
                        InfrastructureErrorCode.InvalidUserData);

                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(
                    $"An unexpected error occurred: {ex.Message}",
                    InfrastructureErrorCode.UnexpectedError);
            }
        }
        #endregion



        #region <-------------> TOOLS <------------->
        /// <summary>
        /// Check if the given Email already exists in the database.
        /// </summary>
        /// <param name="emailToCheck">Email to check in database</param>
        /// <returns>Returns true if the mail exists in the database otherwise false.</returns>
        private async Task<bool> CheckMailAlreadyExist(string emailToCheck)
        {
            var result = await _context.Users
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(x => x.Email == emailToCheck);

            if (result is null)
                return false;

            return true;
        }
        #endregion

    }
}
