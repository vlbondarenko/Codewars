using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ConfiguringApps.Infrastructure
{
    //Класс компонента промежуточного программного обеспечения. Класс не наследует членов от любого другого класса
    //и не реализует какой либо интерфейс.
    public class ContentMiddleware
    {
        private UptimeService uptime;
        private RequestDelegate nextDelegate;


        //Каждый компонент промежуточного программного обеспечения должен содержать в себе конструктор,
        //принимающий аргумент типа RequestDelegate() - это объект, представляющий следующий компонент промежуточного ПО
        //в цепочке.
        //Не только контроллеры, но и компоненты промежуточного ПО могут использовать подключенные в методе
        //ConfigureService() службы
        public ContentMiddleware(RequestDelegate next, UptimeService service)
        {
            nextDelegate = next;
            uptime = service;
        }


        //Каждый компонент промежуточного ПО, должен содержать в себе асинхронный метод Invoke(),
        //который вызывается, когда ASP.Net получает HTTP-запрос
        //В качестве аргумента методу передается объект типа HttpContext, в котором содержится 
        //информация о запросе и ответе, которая будет возвращена пользователю
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().ToLower() == "/middleware")
            {
                await context.Response.WriteAsync("This is from conyent middleware" + $"{uptime.Uptime}ms", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(context);
            }
        }
    }
}
