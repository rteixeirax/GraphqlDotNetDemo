using GraphQL.Server;

using GraphQLDotNet.Src.Data;
using GraphQLDotNet.Src.Data.Repositories;

using GraphqlDotNetDemo.Src.Graphql;
using GraphqlDotNetDemo.Src.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GraphqlDotNetDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphqlDotNetDemo v1"));

                // Graphql playground config (Only in dev)
                app.UseGraphQLPlayground(); // /ui/playground by default
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Graphql Endpoint
            app.UseGraphQL<GraphqlSchema>(); // /graphql by default

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DB config
            string connectionStr = Configuration.GetConnectionString("mysqlConString");
            services.AddDbContext<StorageContext>(opt => opt.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));

            // Repositories Dependency Injection config
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository, Repository>();

            // Services Dependency Injection config
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDataLoaderService, DataLoaderService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();

            // Graphql config
            services.AddScoped<GraphqlSchema>();
            services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(GraphqlSchema), ServiceLifetime.Scoped)
                .AddDataLoader();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphqlDotNetDemo", Version = "v1" });
            });
        }
    }
}
