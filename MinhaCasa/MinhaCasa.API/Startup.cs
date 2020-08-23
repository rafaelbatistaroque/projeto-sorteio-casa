using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Handlers;
using MinhaCasa.Domain.NaoContemplados.Repositories;
using MinhaCasa.Domain.NaoContemplados.Services.CriteriosSelecao;
using MinhaCasa.Domain.NaoContemplados.Services.TipoCategorias;
using MinhaCasa.Infra.Context;
using MinhaCasa.Infra.Repositories;

namespace MinhaCasa.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>();
            services.AddTransient<FiltroNaoContempladosHandler, FiltroNaoContempladosHandler>();
            services.AddTransient<CRUDNaoContempladosHandler, CRUDNaoContempladosHandler>();
            services.AddTransient<INaoContempladosRepository, NaoContempladosRepository>();
            services.AddTransient<IRendaTotalCriterio, RendaTotalCriterio>();
            services.AddTransient<IDependenteCriterio, DependenteCriterio>();
            services.AddTransient<IPretendenteCriterio, PretendenteCriterio>();
            services.AddTransient<ICategoria, Categoria>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
