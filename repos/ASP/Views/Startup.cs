using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Views.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Views
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new SimpleExpander());
            });

           
            #region Добавление своего механизма визуализации
            //Чтобы применить созданный механизм визуализации, нужно добавить его в список ViewEngines
            /* services.Configure<MvcViewOptions>(options =>
             {
                 options.ViewEngines.Clear();
                 options.ViewEngines.Insert(0, new DebugDataViewEngine());
             });*/
            #endregion
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
