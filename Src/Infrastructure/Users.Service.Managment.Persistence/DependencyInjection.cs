using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("UserDatabase")));

            services.AddScoped<IUserDbContext>(provider => provider.GetService<UserDBContext>());

            return services;
        }
    }
}
