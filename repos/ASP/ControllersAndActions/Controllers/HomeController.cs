using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("SimpleForm");


        ////Извлечение данных формы из объекта контекста и передача этих данных в представление

        /*public ViewResult ReceiveForm()
        {
            var name = Request.Form["name"];
            var city = Request.Form["city"];
            return View("Result", $"{name} lives in {city}");
        }*/


        ////В этом варианте метода действия, данные из формы передаются через параметры метода, имена 
        ////которых соответствуют значениям данных формы

        /*public ViewResult ReceiveForm(string name, string city) => View("Result", $"{name} lives in {city}");*/



        ////В этом методе генерируется ответ на низком уровне при помощи объекта HttpResponse

        /*public void ReceiveForm(string name, string city)
        {
            Response.StatusCode = 200;
            Response.ContentType = "text/html";
            byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} lives in {city}</body>");
            Response.Body.WriteAsync(content, 0, content.Length);
        }*/


        ////Результат действия - объект класса CustomHtmlReult - класса, реализующего интерфейс IActionResult
        ////Методы действий заявляют о намерениях по генерации ответа клиенту,а инфраструктура MVC - выполняет эти намерения

        /*public IActionResult ReceiveForm(string name, string city) =>
               new CustomHtmlResult { Content = $"{name} lives in {city}" };*/


        //Применение паттерна Post/Redirect/Get. 
        //Суть паттерна - метод POST должен не отправлять пользователю представление (во избежание
        //повторной отправки форм и т.д., когда возможны непреднамеренные изменения в базах данных),
        //а должен обработать запрос и перенаправить пользователя на Get метод
        [HttpPost]
        public RedirectToActionResult ReceiveForm(string name,string city)
        {
            //Это свойство класса Controller служит для передачи данных между методами действий
            //Так как при перенаправлении создается новый запрос, то нужно предохранить данные, передаваемые в первичном запросе
            //Данные подлежат удалению после прочтения
            TempData["name"] = name;        
            TempData["city"] = city;
           return RedirectToAction(nameof(Data));
        }

        //Метод, на который было совершено перенаправление.
        //Данные из первичного запроса извлекаются при помощи свойства TempData
        public ViewResult Data()
        {
            string name = TempData["name"] as string;
            string city = TempData["city"] as string;
            return View("Result",$"{name} lives in {city}");
        }
         

    }
}
