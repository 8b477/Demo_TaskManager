using ApplicationLayer.TaskManager.Interfaces;
using ApplicationLayer.TaskManager.Services;
using ApplicationLayer.TaskManager.Validations.User;
using DomainLayer.TaskManager.Interfaces;
using InfrastructureLayer.TaskManager.Repositories;

using FluentValidation;
using FluentValidation.AspNetCore;


namespace API.TaskManager.DependencyManager
{
public static class DependencyInjectionManager
    {
        public static void AddDependency(this IServiceCollection service)
        {
            // Controller
            service.AddControllers();

            // Swagger
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();

            // Fluent Validation
            service.AddFluentValidationAutoValidation();
            service.AddValidatorsFromAssemblyContaining<CreateUserDTOValidation>();

            // Contract & Repository
            service.AddScoped<ITodosRepository, TodoRepository>();
            service.AddScoped<IUsersRepository, UserRepository>();
            service.AddScoped<IRolesRepository, RoleRepository>();
            service.AddScoped<ITodoStatusRepository, TodoStatusRepository>();

            // Service
            service.AddScoped<IUserService, UserService>();
        }
    }
}
