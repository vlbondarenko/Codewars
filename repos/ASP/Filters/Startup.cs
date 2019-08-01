using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Filters.Infrastructure;

namespace Filters
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IFilterDiagnosics, FilterDiagnostics>();   //Регистрация службы для распознавания зависимостей в классах фильтров
            services.AddSingleton<IFilterDiagnosics, DefaultFilterDiagnostics>();
            services.AddSingleton<TimeFilter>();        //Регистрация фильтрачерез поставщика служб для управления жизненным циклом служб

            #region Создание глобального фильтра
            /*services.AddScoped<DiagnosticsFilter>();
            services.AddScoped<ViewResultDiagnostics>();
            services.AddMvc().AddMvcOptions(options =>                          //Создание глобального фильтра
            {                                                                   //Глобальный фильтр применяется для каждого метода действия каждого контроллера без явного указания атрибута фильтра
                options.Filters.AddService(typeof(ViewResultDiagnostics));      
                options.Filters.AddService(typeof(DiagnosticsFilter));
            });*/
            #endregion

            services.AddScoped<DiagnosticsFilter>();
            services.AddScoped<ViewResultDiagnostics>();
            services.AddMvc().AddMvcOptions(options =>                         
            {                                                                   
                options.Filters.Add(new MessageAttribute("This is the global filter"));   
            });
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
