using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection
{
    public class Startup
    {
        private IHostingEnvironment env;

        public Startup(IHostingEnvironment env)
        {
            this.env = env;
        }


        #region Цикл жизни создаваемых поставщиком служб объектов
        /*
         AddTransient<service, implType>()                  Этот метод указывает поставщику служб на необходимость 
                                                            создания нового экземпляра типа реализации для каждой 
                                                            зависимости от типа службы
         
         AddTransient<service>()                            Этот метод применяется для регистрации одиночного типа, 
                                                            экземпляр которого будет создаваться для каждой зависимости
                                                            
         AddTransient<service>(factoryFunc)                 Этот метод применяется для регистрации фабричной функции, 
                                                            которая будет вызываться с целью создания объекта реализации 
                                                            для каждой зависимости от типа службы

         AddScoped<service,implType>()                      Эти методы сообщают поставщику о том, что экземпляры типа 
         AddScoped<service>()                               реализации должны использоваться повторно. Таким образом, 
         AddScoped<service>(factoryFunc)                    все запросы к службе со стороны компонентов, ассоциированных 
                                                            с общей областью действия, которой обычно является одиночный 
                                                            НТТР-запрос, разделяют один и тот же объект. 
                                                            Данные методы следуют тому же самому шаблону, 
                                                            что и соответствующие методы AddTransient (). 

         AddSingleton<service,implType>()                   Эти методы указывают поставщику служб на необходимость создания нового
         AddSingleton<service>()                            экземпляра типа реализации для первого запроса к службе и затем его 
         AddSingleton<service> (factoryFunc)                повторного использования для всех последующих запросов к службе.

         AddSingleton<service>(instance)                    Этот метод предоставляет поставщику служб объект, 
                                                            который должен применяться для обслуживания всех запросов к службе. 
                                                            Поставщик служб не будет создавать новые объекты 

        */
        #endregion

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IRepository, MemoryRepository>();       //Эта строка указывает MVC, что в местах где требуются объекты IRepositiry, нужно передавать объект типа MemoryRepository
            //TypeBroker.SetRepositoryType<AlternateRepository>();          //Выбираем нужный тип репозитория через класс TypeBroker

            #region Использование фабричной функции при создании объекта
            /*services.AddTransient<IRepository>(provider=>                   //использование фабричной функции для создания объета IRepository при обнаружении зависимости
            {
                if (env.IsDevelopment())
                {
                    var x = provider.GetService<MemoryRepository>();        //Т.к. внутри класса MemoryRepository, то создаем его объект с применением поставщика служб (строка services.AddTransient<MemoryRepository>();)
                    return x;
                }
                else
                {
                    return new AlternateRepository();
                }
                    
            });
            services.AddTransient<MemoryRepository>();*/
            #endregion

            // services.AddScoped<IRepository, MemoryRepository>();             //В этом случае поставщик служб будет использовать один объект для разных мест в 
                                                                                //приложении при распознавании зависимости, но ТОЛЬКО В ПРЕДЕЛАХ ОДНОГО HTTP-ЗАПРОСА! 
                                                                                //При новом запросе создастся новый объект


            services.AddSingleton<IRepository, MemoryRepository>();             //В этом случае будет использоваться один объект для всех зависимостеи и для всех запросов       
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddTransient<ProductTotalizer>();
            services.AddMvc();
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
