using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Autofac;
using Invoicer.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserService.DataAccess;
using UserService.Models;
using UserService.Repositories;

namespace UserService
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }

        // this method is called by the host!
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            containerBuilder.RegisterType<CommandBus>()
                .As<ICommandBus>()
                .SingleInstance();
            
            containerBuilder.RegisterType<QueryBus>()
                .As<IQueryBus>()
                .SingleInstance();
            
            containerBuilder.RegisterModule(new CommandBusModule()
            {
                ExecutingAssembly = assembly
            });
            containerBuilder.RegisterModule(new QueryBusModule()
            {
                ExecutingAssembly = assembly
            });
            containerBuilder.RegisterModule(new RepositoryModule()
            {
                ExecutingAssembly = assembly
            });
        }
    }
}
