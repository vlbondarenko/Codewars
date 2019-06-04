﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ConfiguringApps.Infrastructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;

        public ErrorMiddleware(RequestDelegate @delegate)
        {
            nextDelegate = @delegate;
        }

        //метод сразу передает запрос следующему компоненту в цепочке. Но при генерации ответа и прохождении его обратно по цепочке, этот метод 
        //будет его редактировать, выдавая вместо ошибок текстовые сообщения
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response.WriteAsync("Edge not supported", Encoding.UTF8);
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("Not content middleware", Encoding.UTF8);
            }
          
        }
    }
}
