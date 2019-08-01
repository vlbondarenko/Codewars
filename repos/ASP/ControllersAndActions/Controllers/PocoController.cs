using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace ControllersAndActions.Controllers
{
    //POCO-контроллеры ("plain old CLR object" - простой старый объект CLR) - простой контроллер.
    //Первый метод - пример чистого контроллера без зависимости от API-интерфейса MVC
    //Второй метод - пример чистого контроллера с зависимостью от API-интерфейса MVC
    public class PocoController
    {

        //С помощью этой переменной будет получен доступ к созданным инфраструктурой MVC объектам
        //HttpRequest и HttpResponse.
        [ControllerContext]   //Этот атрибут устанавливает свойство в объект ControllerContext
        public ControllerContext ControllerContext { get; set; }  //Класс ControllerContext собирает в себе объекты, требующиеся для контроллера

        //Первый простой пример из книги
      /*[Route("[controller]/[action]")]
        public string Index() => "This is a POCO controller";*/

        //Таким способом впростом контроллере можно обработать запрос и вернуть ответ пользователю
        //в виде представления
        public ViewResult Index() => new ViewResult()
        {
            ViewName="Result",
            ViewData=new ViewDataDictionary(new EmptyModelMetadataProvider(),new ModelStateDictionary())
            {
                Model=$"This is POCO controller"
            }
        };

        public ViewResult Headers() => new ViewResult()
        {
            ViewName = "Result",
            ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = ControllerContext.HttpContext.Request.Headers.ToDictionary(kvp=>kvp.Key,
                                kvp=>kvp.Value.First())
            }
        };
    }
}
