using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace UrlsAndRoutes
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc();
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //      name: "Shop2",
                //      template: "Shop/OldAction",
                //      defaults: new { controller = "Home",action="Index" });
                //routes.MapRoute(
                //       name: "Shop",
                //       template: "Shop/{action=Index}",
                //       defaults:new { controller="Home"});
                //routes.MapRoute(
                //       name: "X",
                //       template: "X{controller}/{action}");
                //routes.MapRoute(
                //          name: "customer",
                //          template: "{controller}/{action}");
                //routes.MapRoute(
                //        name: "default",
                //        template: "{controller=Home}/{action=Index}");
                //routes.MapRoute(
                //        name: "",
                //        template: "Public/{controller=Home}/{action=Index}");
                //routes.MapRoute(
                //        name: "MyRoute",
                //        template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");
                routes.MapRoute(
                        name: "MyRoute",
                        template: "{controller=Home}/{action=Index}/{id:int?}");

            });
        }
    }
}
