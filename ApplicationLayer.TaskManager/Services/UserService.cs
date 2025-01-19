using ApplicationLayer.TaskManager.Errors;
using ApplicationLayer.TaskManager.Interfaces;
using DomainLayer.TaskManager.Entities;
using DomainLayer.TaskManager.Interfaces;

using InfrastructureLayer.TaskManager.Exceptions;


namespace ApplicationLayer.TaskManager.Services
{
    public class UserService : IUserService
    {
        // <--------------------------------> TODO <-------------------------------->
        // 
        // <--------------------------------> **** <-------------------------------->


        #region <-------------> DEPENDENCY <------------->
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<ErrorResponseService> AddUserServiceAsync(Users user)
        {
            try
            {
                await _usersRepository.AddUserAsync(user);
                return new ErrorResponseService(true, "User successfully added");
            }
            catch (InfrastructureException ex)
            {
                return new ErrorResponseService(false, ex.Message);
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IEnumerable<Users>> GetAllUserServiceAsync()
        {
            return await _usersRepository.GetAllUsersAsync() ?? [];
        }

        public async Task<IEnumerable<Todos>> GetTodosByUserIdServiceAsync(Guid userId)
        {
            return await _usersRepository.GetTodosByUserIdAsync(userId) ?? [];
        }

        public async Task<Users?> GetUserByEmailServiceAsync(string email)
        {
            return await _usersRepository.GetUserByEmailAsync(email);
        }

        public async Task<Users?> GetUserByIdServiceAsync(Guid id)
        {
            return await _usersRepository.GetUserByIdAsync(id);
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<ErrorResponseService> UpdateUserServiceAsync(Users user)
        {
            var result = await _usersRepository.UpdateUserAsync(user);
            return new ErrorResponseService(true, "not ipmplementntntntntnt");
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<ErrorResponseService> DeleteUserServiceAsync(Guid id)
        {
            try
            {
                var result = await _usersRepository.DeleteUserAsync(id);
                return new ErrorResponseService(true, "User correctly deleted");
            }
            catch (ArgumentNullException)
            {
                return new ErrorResponseService(false, $"The User whose id : {id} has not been deleted");
            }
        }
        #endregion



        #region <-------------> TOOLS <------------->

        #endregion

    }
}
