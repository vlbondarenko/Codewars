﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index() => View("Result",
            new Result { Controller = nameof(HomeController), Action = nameof(Index) });


        //Через URL можно передавать значения в методы действия, но только в том случае, 
        //если имя параметра мтода совпадает с названием переменной шаблона URL
        public ViewResult CustomVariable(string id,string catchall)
        {
            Result r = new Result
            {
                Controller=nameof(HomeController),
                Action=nameof(CustomVariable)
            };
            r.Data["id"] = id??"<no value>";
            //r.Data["catchall"] = catchall ?? "<no value>";
            r.Data["catchall"] = RouteData.Values["catchall"]?? "<no value>";
            return View("Result",r);
        }
    }
}
