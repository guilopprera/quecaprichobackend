using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueCapricho.Infra.Data.Context;

namespace QueCapricho.Service.Api.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MeuContexto>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("ConnectionQueCaprichoBD")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MeuContexto>();

            return services;
        }
    }
}
