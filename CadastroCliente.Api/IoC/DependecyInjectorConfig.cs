using Application.Contratos;
using Application;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Repository.Contratos;
using Repository.Repositorios;
using Repository.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Api.IoC
{
    public static class DependecyInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddDbContext<ClienteContexto>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            })
                    .AddRoles<Role>()
                    .AddRoleManager<RoleManager<Role>>()
                    .AddSignInManager<SignInManager<User>>()
                    .AddRoleValidator<RoleValidator<Role>>()
                    .AddEntityFrameworkStores<ClienteContexto>()
                    .AddDefaultTokenProviders();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IGeralRepository, GeralRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IClienteService, ClienteService>();


        }
    }
}
