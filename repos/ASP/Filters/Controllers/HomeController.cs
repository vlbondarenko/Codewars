using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filters.Infrastructure;

namespace Filters.Controllers
{

    #region Кратко о фильтрах

    //Не всякий атрибут является фильтром. Фильтрами являются атрибуты, классы которых реализуют
    //пустой интерфейс IFilterMetadata.
    //Виды фильтров:
    //
    //      **Разновидность**               **Интерфейсы**                  **Описание**
    //
    //      Фильтры авторизации             IAuthorizationFilter            Этот тип фильтров используется для применения 
    //                                      IAsyncAuthorizationFilter       политики безопасности приложения, включая 
    //                                                                      авторизацию пользователей
    //                                      
    //      Фильтры действий                IActionFilter                   Этот тип фильтров используется для выполнения 
    //                                      IAsyncActionFilte               работы немедленно перед или после выполнения метода действия
    //
    //      Фильтры результатов             IResultFilter                   Этот тип фильтров используется для выполнения
    //                                      IAsyncResultFilter              работы немедленно перед или после обработки результата, 
    //                                                                      полученного из метода действия
    //
    //      Фильтры исключений              IExceptionFilter                Этот тип фильтров используется для обработки исключений
    //                                      IAsyncExceptionFilter
    //Фильтры обеспечиваются данными контекста в форме объекта FilterContext.
    //Класс FilterContext является производным от ActionContext, 
    //который также представляет собой базовый класс для класса ControllerContext
    //Фильтры применяются в особом порядке. Фильтры авторизации выполняются первыми, 
    //за ними идут фильтры действий, а затем фильтры результатов. 
    //Фильтры исключений выполняются только в случае генерации какого-либо исключения, 
    //которое нарушает нормальную последовательность
    //Когда фильтр делается производным от одного из удобных классов атрибутов, 
    //таких как ExceptionFilterAttribute, для обработки каждого запроса 
    //инфраструктура MVC создает новый экземпляр класса фильтра. 
    //По умолчанию инфраструктура MVC запускает глобальные фильтры. 
    //Затем фильтры, примененные к классу контроллера, и в заключение фильтры, 
    //которые применены к методам действий. После того, как метод действия вызван 
    //или результат действия обработан, стек фильтров раскручивается, из-за чего 
    //сообщения After Result в выводе расположены в обратном порядке
    #endregion


    //[RequireHttps]        //Если требуется применить атрибут RequireHttps ко всем методам действия в контроллере, то следеет применить этот атрибут к классу
    //[HttpsOnly]           //Примемнение созданного фильтра HttpsOnlyAttribute для обработки запросов поступающих только по протоколу https
    //[Profile]             //Применения фильтра действия ProfileAttribute для вывода времени в мс, которое потребовалосб для обработки запроса методом действия
    //[ViewResultDetails]   //Применения фильтра результата действия ViewResultDetailsAttribute для вывода данных о результате, выданным методом действия
    //[RangeException]      //Применение фильтра исключений
    //[TypeFilter(typeof(TimeFilter))]        //Применение фильтров с внедренными зависимостями атрибут TypeFilter позволяет классу фильтра объявлять зависимости, которые распознаются посредством поставщика служб.
    //[ServiceFilter(typeof(DiagnosticsFilter))]      //Этот атрибут позволяет создавать объект фильтра через поставщика служб, что позволяет управлять жизненным циклом объектов фильтров
    [Message("This is the Controller-Scoped filter", Order = 10)]   //Эти атрибуты нужны для демонстрации порядка применения фильтров
    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Fil ter", Order = 1)]     //При помощи свойства Order можно менять порядок применения фильтров - фильтр с меньшим значением этого свойства будет применяться раньше
        [Message("This is the Second Action-Scoped Filter",Order = -1)]
        public ViewResult Index() =>
            View("Message", "This is the Index action on the Home controller");


        #region Применение фильтра исключений

        public ViewResult GenerateException(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            else if (id > 10)
                throw new ArgumentOutOfRangeException(nameof(id));
            else
                return View("Message", $"The value is {id}");

        }

        #endregion

        #region Применение политики безопасности без применения фильтров
        /*public IActionResult Index()
        {
            if(Request.IsHttps)
            {
                return new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
            else
            {
                return View("Message", "This is the Index action on the Home controller");
            }
        }*/
        #endregion

        #region Пименение политики безопасности с примением фильтров

        //Примемние атрибута позволяет обрабатывать запросы, поступающие только по протоколу https
        //Атрибут перенаправляет клиента на изначально запрошенный Url но деает это с использованием схeмы HTTPS
        //Запрос по Url http://localhost/Home/Index будет перенаправлен на https://localhost/Home/Index. 
        /*[RequireHttps]
        public ViewResult Index() =>
            View("Message", "This is the Index action on the Home controller");

        [RequireHttps]
        public ViewResult SecondAction() =>
            View("Message", "This is the SecondAction action on the Home controller");*/

        #endregion

    }
}
