using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using testexperticket.Core;
using testexperticket.Core.Extensions;

namespace testexperticket.webapi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        private IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Our CQRS
            services.AddMessageManager(this.Configuration);

            // API
            services.AddHttpContextAccessor();
            services.AddScoped<ILinkManager, LinkManager>();
            services.AddSwaggerGen(builder => {
                builder.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Experticket API",
                    Version = "v1",                    
                });
                builder.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{this.GetType().Assembly.GetName().Name}.xml");
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Not today
            // app.UseHttpsRedirection();

            app.UseRouting();

            // Not today
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            // API
            app.UseSwagger();
            app.UseSwaggerUI(builder =>builder.SwaggerEndpoint("/swagger/v1/swagger.json", "Experticket API"));
        }
    }
}
