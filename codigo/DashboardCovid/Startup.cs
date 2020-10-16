using Autofac;
using AutoMapper;
using DashboardCovid.Data;
using DashboardCovid.Infra.CrossCutting.IoC;
using DashboardCovid.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DashboardCovid
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IWebHostEnvironment env)
        {
            this.env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        //Configura inje��o de servi�os para uso posterior
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Configura��o da inje��o de depend�ncia
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Configura��o do contexto do banco de dados
            services.AddDbContext<DashboardCovidContexto>(options => options.UseSqlite($"Data Source={env.ContentRootPath}/dashboardCovid.db"));

            //Configura��o das configura��es presentes no appsettings
            services.ConfigureAppConfiguration<Aplicacao>(Configuration.ObterConfiguracao());
        }

        //Configura��es pr�-definidas para execu��o da aplica��o
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //Configura container para inje��o de depend�ncias 
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddAutofacServiceProvider();
        }
    }
}
