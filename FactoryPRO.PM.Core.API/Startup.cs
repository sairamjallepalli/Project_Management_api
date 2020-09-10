using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FactoryPRO.PM.Core.API.Services;
using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.DAL.Repository;
using Serilog;
using Serilog.Core;
using FactoryPRO.PM.Core.DAL.Models;

namespace SolSem.PLM.Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "myTestService", Version = "v1" });
              //  c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });


            services.AddControllers();
            services.AddScoped<ISpaceService, SpaceService>();
            services.AddScoped<ISpaceRepository, SpaceRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<IListRepository, ListRepository>();
          //  services.AddSingleton<Logger, LoggerConfiguration>();
            services.AddScoped<APIResponse>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITilesService, TilesService>();

            services.AddAutoMapper(typeof(Startup));
           services.AddDbContext<ProjectContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyTestService", Version = "v1", });
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);

            //});


            //var contact = new OpenApiContact()
            //{
            //    Name = "FirstName LastName",
            //    Email = "user@example.com",
            //    Url = new Uri("http://www.example.com")
            //};

            //var license = new OpenApiLicense()
            //{
            //    Name = "My License",
            //    Url = new Uri("http://www.example.com")
            //};

            //var info = new OpenApiInfo()
            //{
            //    Version = "v1",
            //    Title = "Swagger Demo API",
            //    Description = "Swagger Demo API Description",
            //    TermsOfService = new Uri("http://www.example.com"),
            //    Contact = contact,
            //    License = license
            //};

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", info);
            //});

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
          //  app.UseSerilogRequestLogging();

            app.UseAuthorization();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json",
            //    "Swagger Demo API v1");
            //});

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestService");
            });


            //app.UseSwagger(c =>
            //{
            //    c.RouteTemplate = "Space/swagger/{documentName}/swagger.json";
            //});


            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/Space/swagger/v1/swagger.json", "TestService");
            //    c.RoutePrefix = "Space/swagger";
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }
    }
}
