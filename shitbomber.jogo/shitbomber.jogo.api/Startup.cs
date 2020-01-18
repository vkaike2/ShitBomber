using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using shitbomber.jogo.api.ExceptionFilter;
using shitbomber.jogo.data.Context;
using shitbomber.jogo.data.Repository;
using shitbomber.jogo.domain.IRepository;
using shitbomber.jogo.domain.IServiceBus;
using shitbomber.jogo.domain.IServices;
using shitbomber.jogo.service.ServiceBus;
using shitbomber.jogo.service.Services;

namespace shitbomber.jogo.api
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
            services.AddDbContext<JogoContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"],
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(JogoContext).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                        });
            });

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            });

            services.AddControllers();

           
            this.IoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void IoC(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IConnectionFactoryCreator, ConnectionFactoryCreator>();
            services.AddTransient<ITesteServiceBus, TesteServiceBus>();

            List<Type> assembly = Assembly.Load("shitbomber.jogo.service")
                                     .GetExportedTypes()
                                     .Where(x => !string.IsNullOrEmpty(x.Namespace))
                                     .Where(x => !x.IsGenericType)
                                     .Where(x => x.Namespace.StartsWith("shitbomber.jogo.service.Services")).ToList();

            foreach (Type reg in assembly)
            {
                services.AddTransient(reg.GetInterfaces().Single(x => !x.IsGenericType), reg);
            }


            //services.BuildServiceProvider().GetService<ITesteServiceBus>().Subscribe();
           
        }

    }
}
