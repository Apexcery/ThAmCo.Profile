using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThAmCo.Profile.Data;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Mapper;
using ThAmCo.Profile.Repositories;
using ThAmCo.Profile.Services.Accounts;
using ThAmCo.Profile.Services.Orders;

namespace ThAmCo.Profile
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProfileDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("ProfileDbConnectionString"));
            });

            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(ProfileMapper));

            if (Env.IsDevelopment())
            {
                services.AddSingleton<IOrdersService, MockOrdersService>();
                services.AddSingleton<IAccountsService, MockAccountsService>();
                services.AddSingleton<IProfileRepository, MockProfileRepository>();
            }
            else
            {
                services.AddScoped<IOrdersService, OrdersService>();
                services.AddHttpClient<IAccountsService, AccountsService>(options => options.BaseAddress = new Uri(Configuration["AppSettings:Endpoints:AccountsEndpoint"]));
                services.AddScoped<IProfileRepository, ProfileRepository>();
            }

            services.AddControllersWithViews();
        }

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ThAmCo Profile API");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Profile}/{action=Index}/{id?}");
            });
        }
    }
}
