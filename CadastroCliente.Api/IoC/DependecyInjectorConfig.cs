using Application.Contratos;
using Application;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Repository.Contratos;
using Repository.Repositorios;
using Repository.Contexto;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Api.Helpers;

namespace CadastroCliente.Api.IoC
{
    public static class DependecyInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ILogradouroRepository, LogradouroRepository>();
            services.AddScoped<ILogradouroService, LogradouroService>();
            services.AddScoped<IGeralRepository, GeralRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUtil, Util>();
        }
    }
}
