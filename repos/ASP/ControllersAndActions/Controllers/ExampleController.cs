using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ControllersAndActions.Controllers
{
    public class ExampleController:Controller
    {
        //Передача модели в модель представленич через параметр метода View()
       /* public ViewResult Index() =>
            View(DateTime.Now);*/

        //Использование свойств динамического объекта для передачи данных в модель представления
        /*public ViewResult Index()
        {
            ViewBag.Message = "Hello World!";
            ViewBag.Date = DateTime.Now;
            return View();
        }*/

        //При передачи в метод View() одного аргумента типа string, нужно обязательно явно привести передаваемую строку 
        //в тип string, т.к. перегрузка метода с одним параметром типа string ищет представление, название
        //которого соответствует переданной строке, вместо того чтобы передать строку в модель представления в качестве модели
        public ViewResult Result() =>
            View((object)"Hello World!");

        //Временное перенаправление на другой URL. Код состояния HTTP в ответе - 302
        /*public RedirectResult Redirect() =>
            Redirect("/Example/Index");*/

        //Постоянное перенаправление на другой URL. Код состояния HTTP в ответе - 301
        //При использовании постоянного перенаправления браузер запоминает его и будет постоянно 
        //транслировать запрос Url вида "/Example/Redirect" в запрос "/Example/Index", не
        //контактируя с сервером
        /*public RedirectResult Redirect() =>
            RedirectPermanent("/Example/Index");*/

        //Редирект с использованием системы маршрутизации, код сосотояния HTTP - 302
        //Данный вариант предподчительнее, нежели вариант с жестким кодированием URL
        /* public RedirectToRouteResult Redirect() =>
             RedirectToRoute(new
             {
                 controller = "Example",
                 action = "Index",
                 iD = "MyID"
             });*/


        //Перенаправление на метод действия без применения системы маршрутизации
        //Если не указывать имя контроллера (второй параметр), то инфраструктура MVC будет искать указанный
        //метод действия в текущем контроллере
        public RedirectToActionResult Redirect() =>
            RedirectToAction("Headers","Derived");



        //Генерация методом действия ответа в виде JSON-файла
        /*public JsonResult Index() =>
            Json(new[] { "Alice","Bob","Joe"});*/


        //Генерация ответа в виде объекта
        //В HTTP-запросе есть заголовок Accept, в котором указываютсяформаты файлов, поддерживаемые браузером
        //Например, для Google Chrome этот заголовок будет содеожать следующую запись
        //Accept : text/html,application/xhtml+xml,application/xml; 
        //q=0.9,image/webp,*/*;q=0.8
        /* public ObjectResult Index() =>
             Ok(new[] { "Alice", "Bob", "Joe" });*/


        //Метод для отправки клиенту сообщений об ошибках и результирующих кодов HTTP
        /*public StatusCodeResult Index() =>
            StatusCode(StatusCodes.Status404NotFound); */


        //Можно отправить клиенту сообщение об ошибках и результирующих кодов при помощи удобного метода
        public StatusCodeResult Index() =>
            NotFound();
    }
}
