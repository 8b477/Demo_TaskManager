using DomainLayer.TaskManager.Interfaces;

using InfrastructureLayer.TaskManager.Repositories;

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

            // Contract & Repository
            service.AddScoped<ITodosRepository, TodoRepository>();
            service.AddScoped<IUsersRepository, UserRepository>();
            service.AddScoped<IRolesRepository, RoleRepository>();
            service.AddScoped<ITodoStatusRepository, TodoStatusRepository>();
        }
    }
}
