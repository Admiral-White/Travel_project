using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Travel.Application;
using Travel.Data;
using Travel.Data.Contexts;
using Travel.Identities;
using Travel.Identities.Helpers;
using Travel.Shared;
using Travel.WebApi.Extensions;
using Travel.WebApi.Filter;
using Travel.WebApi.Helper;

namespace Travel.WebApi
    

    
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
            services.AddApplication(Configuration);
            services.AddInfrastructureData(Configuration);
            services.AddInfrastructureShared(Configuration);
            services.AddInfrastructureIdentity(Configuration);

            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddControllersWithViews(options => options.Filters.Add(new ApiExceptionFilter()));
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddApiVersioningExtension();
            services.AddVersionedApiExplorerExtension();
            services.AddSwaggerGenExtension();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerExtension(provider);
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
