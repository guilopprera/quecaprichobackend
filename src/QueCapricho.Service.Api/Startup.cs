using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueCapricho.Application.Interfaces;
using QueCapricho.Application.Services;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using QueCapricho.Infra.Data.Repositories;
using QueCapricho.Service.Api.Configurations;

namespace QueCapricho.Service.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
             services.AddCors(options =>
            {
                options.AddPolicy("politicaCors",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddControllers();


            services.AddDbContext<MeuContexto>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("ConnectionQueCaprichoBD")));

            services.AddIdentityConfiguration(Configuration);
            services.AddMvc();
            services.AddCors();

            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICategoriaProdutoAppService, CategoriaProdutoAppService>();
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEncomendaAppService, EncomendaAppService>();
            services.AddScoped<IEncomendaRepository, EncomendaRepository>();
            services.AddScoped<ILogAppService, LogAppService>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ITelefoneAppService, TelefoneAppService>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("politicaCors");
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
