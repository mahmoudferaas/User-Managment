using BaseClasses.AuthenticationService.Configuration;
using FluentValidation.AspNetCore;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Service.Managment.Application;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Infrastructure;
using Users.Service.Managment.Persistence;
using Users.Service.Managment.Persistence.ElasticSearch.Common;
using Users.Service.Managment.WebApi.Controllers;
using Users.Service.Managment.WebApi.Services;

namespace Users.Service.Managment.WebApi
{
    public class Startup
    {
        private IServiceCollection _services;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceCollectionAuthenticationConfiguration.ConfigureAuthenticationServiceCollection(services);

            services.AddInfrastructure(Configuration, Environment);
            services.AddPersistenceES();
            services.AddPersistence(Configuration);
            services.AddApplication();

            //services.AddHealthChecks().AddDbContextCheck<UserDBContext>();

            //services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICurrentUserService, DummyCurrentUserService>();

            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddServices(sp)
                .AddAuthorizeDirectiveType()
                .AddQueryType<UserSchema>()
                .Create());

            services.AddHttpContextAccessor();

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IUserDbContext>());

            services.AddRazorPages();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseStaticFiles();

            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";  
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.UseGraphQL(new PathString("/graphql"));
            app.UsePlayground(new PathString("/graphql"));
        }
    }
}