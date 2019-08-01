using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Users.Models;
using Users.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace Users
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            //Добавление специального класа проверки паролей
            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
            services.AddSingleton<IClaimsTransformation, LocationClaimsProvider>();
            services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();
            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("DCUsers", policy =>
                 {
                     policy.RequireRole("Users");
                     policy.RequireClaim(ClaimTypes.StateOrProvince, "DC");
                 });
                opts.AddPolicy("NotBob", policy =>
                 {
                     policy.RequireAuthenticatedUser();
                     policy.AddRequirements(new BlockUsersRequirement("Bob"));
                 });
                opts.AddPolicy("AuthorsAndEditors", policy =>
                {
                    policy.AddRequirements(new DocumentAuthorizatioRequirement { AllowAuthors=true,AllowEditors=true});
                });
            });
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["Data:SportStoreIdentity:ConnectionString"]));

            services.AddIdentity<AppUser, IdentityRole>(opts=>
            {
                //Установка свойств для проверки корректности введкнного email(введенный емайл должен быть уникальным) и имени пользователя(имя пользователя может содержать только указанные символы)
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            //AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}
