using BaseClasses.Configurations.Manager.Managers;
using Microsoft.Extensions.DependencyInjection;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Persistence.ElasticSearch.MarkupPlan;
using Users.Service.Managment.Persistence.ElasticSearch.PointsRedeemPlan;
using Users.Service.Managment.Persistence.ElasticSearch.User;

namespace Users.Service.Managment.Persistence.ElasticSearch.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceES(this IServiceCollection services)
        {
            services.AddScoped<IUserES, UserEs>();
            services.AddScoped<IMarkupPlanES, MarkupPlanEs>();
            services.AddScoped<IPointRedeemPlanES, PointsRedeemPlanEs>();
            services.AddScoped<IConfigurationManager, ConfigurationManager>();
            return services;
        }
    }
}