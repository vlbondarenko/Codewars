using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class CustomerController : Controller
    {
        //При помощи данного атрибута указывается маршрут к методу действия CustomerController.Index()
        //Маршрут вида /myroute явлется завершенным для доступа к методу действия Index().
        //Применение стандартного маршрута вида Customer/Index больше не будет давать совпадений.
        [Route("myroute")]
        public ViewResult Index() => View("Result", 
            new Result { Controller = nameof(CustomerController), Action = nameof(Index) });

        public ViewResult List() => View("Result", 
            new Result { Controller = nameof(CustomerController), Action = nameof(List) });
    }
}