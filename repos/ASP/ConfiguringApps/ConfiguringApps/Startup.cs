using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps
{   //Класс, который применяется для создания служб (объектов, предоставляющих общую 
    //функциональность повсюду в приложении) и компонентов промежуточного программного
    //обеспечения, используемых для обработки HTTP-запросов.
    public class Startup
    {
        //При запуске приложения, создается новый экземпляр класса Startup(), далее вызывается метод 
        //ConfigureServices(), в котором происходит создание служб
        //
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();      //Добавление функциональности ASP.Net Core
            
            //Подключение созданной службы
            //services.AddSingleton<UptimeService>();       //Создание единственного объекта службы при старе приложения. Этот объект может использоваться в любых частях приложения 
           
            services.AddTransient<UptimeService>();         //Создание нового объекта службы при каждом запросе
        }

        //Метод, который вызывается после метода ConfigureServices(). В нем происходит настройка конвеера запросов.
        //Конвеер запросов - набор компонентов (называемые промежуточным программным обеспечением),
        //который необходим для обработки входящих запросов и генерации ответов на эти запросы.
        //Каждый новый запрос передается первому компоненту в цепочке конвеера запросов, далее этот
        //компонент решает передавать ли запрос следующему компоненту или сгенерировать ответ.
        //Последний компонент цепочки генерирует ответ, этот ответ проходит по всей цепочке обратно и 
        //middleware-компоненты могут обрабатывать и изменять этот ответ
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            //если среда размещения dev - то применить следующие компоненты промежуточного ПО
            if (env.IsDevelopment() == true)
            {
               app.UseMiddleware<ErrorMiddleware>();            //просежуточное ПО для редактирования ответов
               app.UseMiddleware<BrowserTypeMiddleware>();      //промежуточное ПО для редактирования запросов
               app.UseMiddleware<ShortCircuitMiddleware>();     //промежуточное ПО для обхода
               app.UseMiddleware<ContentMiddleware>();          //компонент для генерации содержимого
            }  
            app.UseMvc(route => route.MapRoute(                 //компонент для генерации содержимого
                name: "default",
                template:"{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
