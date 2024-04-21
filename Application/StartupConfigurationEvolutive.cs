using Business.IServices;
using Business.Services;
using DataAccessLayer.Repository;
using DomainLayer.IRepositories;

namespace Application
{
    public class StartupConfigurationEvolutive
    {
        // Divers services
        public static void InjecterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        // Divers Repositories
        public static void InjecterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }
    }
}
