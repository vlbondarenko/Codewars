using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {

        private UptimeService uptime;

        //Для получения доступа к службе, подключенной в методе ConfigureService(), нужно создать 
        //конструктор, который принимает аргумент с нужным типом службы.
        //При обращении к контроллеру HomeController (при каждом запросе будет создаваться новый 
        //экземпляр контроллера), MVC инспектирует класс контроллера, определяет, что для конструктора 
        //нужен объект службы UptimeService.Затем MVC инспектирует набор служб, 
        //которые были сконфигурированы в классе Startup, выясняет, что служба UptimeService 
        //сконфигурирована так. чтобы для всех запросов применялся единственный объект UptimeService,
        //и передает этот объект в качестве аргумента конструктору при создании экземпляра HomeController. 
        public HomeController(UptimeService service)
        {
            uptime = service; 
        }

        public ViewResult Index() => View(new Dictionary<string, string> { ["Message"] = "This is the Index Controller", ["Uptime"] = $"{uptime.Uptime}ms" });

       
    }
}
