using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate requestDelegate)
        {
            nextDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["EdgeBrowser"] as bool?==true)        //если пользователь открыываетстраницу в браузере Edge
            {
                httpContext.Response.StatusCode = 403;                  //то будет возвращена ошибка 403, запрос следующему компоненту отдан не будет
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
