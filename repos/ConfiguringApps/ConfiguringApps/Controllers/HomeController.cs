using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;

        public HomeController(UptimeService service)
        {
            uptime = service;
        }

        public ViewResult Index() => View(new Dictionary<string, string> { ["Message"] = "This is the Index Controller", ["Uptime"] = $"{uptime.Uptime}ms" });
    }
}
