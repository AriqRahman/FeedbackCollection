using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackCollectionAPI.DataManager.IRepository;
using FeedbackCollectionAPI.DataManager.RepositoryManager;
using FeedbackCollectionAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FeedbackCollectionAPI
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

            services.AddDbContext<Feedback_Collection_DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FeedbackCollectionConnectionString")));



            ScopeSection(services);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }




        public void ScopeSection(IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepositoryManager>();
        }

    }
}
