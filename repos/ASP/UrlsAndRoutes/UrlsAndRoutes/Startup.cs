using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing.Constraints;
using UrlsAndRoutes.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace UrlsAndRoutes
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            //Данная строка позволяет применять специальное ограничение как встроенное,
            //с применением синтаксиса {имя_переменной:weekday?}
            services.Configure<RouteOptions>(options=>options.ConstraintMap.Add("weekday",typeof(WeekDayConstraint)));
            services.AddMvc();
        }

     
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();

            //Промежуточное ПО для подключения статических файлов
            app.UseStaticFiles();

            //Подключение компонентов MVC для обработки запросов с применением стандартной маршрутизации.
            //Стандартный маршрут будет сопоставляться с URL, используя следующий шаблон: 
            //{controller}/{action}/{id?}
            app.UseMvcWithDefaultRoute();



            //Подключение компонентов MVC для обработки запросов. Правило - указывать более специфичные 
            //шаблоны URL перед менее специфичными
            //app.UseMvc(routes =>
            //{
                //********************Далее продемонстрированы примеры маршрутизации на основе соглашений*****************************

                //URL сопоставляется со статическим шаблоном. Если совпадение найдено, то запрос отправляется
                //на обработку методу контроллера, указанному в анонимном типе параметра defaults. 
                //В анонимном типе параметра defaults  указываются стандартные значения
                
                //routes.MapRoute(
                //      name: "Shop2",
                //      template: "Shop/OldAction",
                //      defaults: new { controller = "Home", action = "Index" });


                //URL сопоставляется с шаблоном, состоящим из статического сигмента и сегмента со встроенным стандартным значением.
                //Стандартное значение для контроллера вынесено в анонимный тип
                //Если будет совпадение по первому сегменту, то будет выполнено действие по маршруту Home/Index
                
                //routes.MapRoute(
                //       name: "Shop",
                //       template: "Shop/{action=Index}",
                //       defaults: new { controller = "Home" });


                //Первый сегмент - комбинация статического и динамического сегментов. Будут обрабатываться URL вида
                //XHome/Index,XAdmin/Index
                
                //routes.MapRoute(
                //       name: "X",
                //       template: "X{controller}/{action}");


                //Оба сегмента содержат переменные. Будет сопоставляться с шаблоном любой URL, состоящий из 2-х сегментов
                
                //routes.MapRoute(
                //          name: "customer",
                //          template: "{controller}/{action}");


                //Будут сопоставляться любые URL содержащие 0-2 сегмента. Любые неуказанные сегменты будут заменяться 
                //встроенными стандартными значениями

                //routes.MapRoute(
                //        name: "default",
                //        template: "{controller=Home}/{action=Index}");



                //routes.MapRoute(
                //        name: "",
                //        template: "Public/{controller=Home}/{action=Index}");


                //Третий сегмент - специальный, и он может как иметь какое-то значение, так и быть равным null
                //(об этом говорит вопросительный знак после названия переменной).
                //Этот маршрут будет сопоставляться с URL, содержащими любое количество сегментов.Четвертый 
                //и последующие сегменты будут содержаться в переменной catchall - все это достигается благодаря 
                //символу * перед переменной

                //routes.MapRoute(
                //        name: "MyRoute",
                //        template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");


                //В данном и следующем примере, на переменную третьего сегмента накладывается ограничение - 
                //эта переменная должна преобразовываться в тип int или же должна быть равной null.
                //Microsoft.AspNetCore.Routing.Constraints содержит набор классов, с помощью которых 
                //можно ограничивать значения специальных переменных шаблона URL (например, переменная должна преобразовываться
                //в формат DateTime, должна соответствовать строке с определенным количеством символов, солжна соответствовать
                //регулярным выражениям, должна соответствовать любому из примитивных типов)
                //routes.MapRoute(
                //        name: "MyRoute",
                //        template: "{controller=Home}/{action=Index}/{id:int?}");
                //routes.MapRoute(
                //        name: "MyRoute_2",
                //        template: "{controller}/{action}/{id?}",
                //        defaults:new {controller="Home",action="Index" },
                //        constraints: new { id = new IntRouteConstraint()});


                //В данном примере, значения переменных ограничиваются при помощи регулярных выражений.
                //Ограничение переменной controller - совпадение с шаблоном будет тлько в том случае
                //если переменная первого сегмента URL будет начинаться с буквы 'H'. Если в URL
                //отсутствует значение для переменной controller, то сначала переменной
                //первого сегмента присваивается встроенное стандартное значение, а только потом проверяется ограничение
                //Т.к. Home начинается с 'H', то проверка будет успешной и совпадение произойдет
                //Ограничение переменной action - здесь совпадение произойдет только в двух случаях:
                //когда переменная action равна либо Index либо About
                //routes.MapRoute(
                //        name: "MyRoute_3",
                //        template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}");


                ////Применение нескольких ограничений (через знак ':') к переменной id
                //routes.MapRoute(
                //        name: "MyRoute_4",
                //        template: "{controller=Home}/{action=Index}" + "/{id:alpha:minlength(б)?}");


                //Применение специального ограничения к переменной id
                //routes.MapRoute(
                //       name: "MyRoute",
                //       template: "{controller}/{action}/{id?}",
                //       defaults:new {controller = "Home",action = "Index" },
                //       constraints:new { id=new WeekDayConstraint()});


                
            //});
        }
    }
}
