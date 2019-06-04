using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextDelegate;
        public BrowserTypeMiddleware(RequestDelegate @delegate)
        {
            nextDelegate = @delegate;
        }


        //метод редактирует запрос (создает запись с ключом "EdgeBrowser" и записывает значение "edge") 
        //и отдает запрос следующему компоненту в цепочке. Благодаря этому редактированию запроса, пользователь
        //не сможет получить ответ на запрос с любого браузера, будет возвращена ошибка 403
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(v=>v.ToLower().Contains("edge"));
            await nextDelegate.Invoke(httpContext);
        }
    }
}
