using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TpixAPI.Models;
using TpixAPI.Services;

namespace TpixAPI
{
    public class Startup
    {
        private static string _contentRootPath = String.Empty;
        public Startup(IHostingEnvironment env,IConfiguration configuration)
        {
            _contentRootPath = env.ContentRootPath;
            //Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(_contentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TpixContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TpixDatabase")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
