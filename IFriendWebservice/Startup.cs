using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFriendWebservice.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IFriendWebservice
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=IfriendDB;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<dummyIfriendDBContext>(options => options.UseSqlServer(connection));

            var connection = @"Server=frienddb.database.windows.net;Database=FriendDatabase;User ID=avengers;Password=Mads12345;Trusted_Connection=false;Encrypt=True;ConnectRetryCount=0";
            services.AddDbContext<FriendDatabaseContext>(options => options.UseSqlServer(connection));
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
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
