using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    //Пример контроллера унаследованного от базового класса контроллеров.
    //ВНИМАНИЕ! При каждом HTTP-запросе создается новый экземпляр класса контроллера!
    //Поэтому синхронизировать доспук к полям и методам экземпляра не нужно
    public class DerivedController:Controller
    {
        public ViewResult Index() => View("Result",$"This is a Derived controller");

        public ViewResult Headers() => View(
            "DictionaryResult",
            Request.Headers.ToDictionary(kvp=>kvp.Key,kvp=>kvp.Value.First()));
    }
}
