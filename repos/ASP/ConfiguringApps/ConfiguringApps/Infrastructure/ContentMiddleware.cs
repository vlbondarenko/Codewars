using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMiddleware
    {
        private UptimeService uptime;
        private RequestDelegate nextDelegate;
        public ContentMiddleware(RequestDelegate request,UptimeService service)
        {
            nextDelegate = request;
            uptime = service;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().ToLower() == "/middleware")
            {
                await context.Response.WriteAsync("This is from conyent middleware"+$"{uptime.Uptime}ms",Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(context);
            }
        }
    }
}
