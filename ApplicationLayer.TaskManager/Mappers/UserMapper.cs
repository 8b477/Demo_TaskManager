using ApplicationLayer.TaskManager.DTOs.UserDTOs;

using DomainLayer.TaskManager.Entities;


namespace ApplicationLayer.TaskManager.Mappers
{
    public static class UserMapper
    {
        public static Users ToEntity(this CreateUserDTO user)
        {
            return new Users
            {
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.Password
            };
        }
    }
}
