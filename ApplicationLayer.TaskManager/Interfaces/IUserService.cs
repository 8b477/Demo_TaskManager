using ApplicationLayer.TaskManager.Errors;
using DomainLayer.TaskManager.Entities;

namespace ApplicationLayer.TaskManager.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<Users>> GetAllUserServiceAsync();
        public Task<Users?> GetUserByIdServiceAsync(Guid id);
        public Task<ErrorResponseService> AddUserServiceAsync(Users user);
        public Task<ErrorResponseService> UpdateUserServiceAsync(Users user);
        public Task<ErrorResponseService> DeleteUserServiceAsync(Guid id);
        public Task<Users?> GetUserByEmailServiceAsync(string email);
        public Task<IEnumerable<Todos>> GetTodosByUserIdServiceAsync(Guid userId);
    }
}
