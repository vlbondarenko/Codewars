using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControllersAndActions.Infrastructure
{
    //Класс результата действия.
    //Объект класса может быть возвращен из метода действия в качестве овета пользователю 
    //благодаря реализации интерфейса IActionResult
    public class CustomHtmlResult:IActionResult
    {

        public string Content { get; set; }


        //В качестве аргумента данный метод принимает объект типа ActionContext - супертипа для класса
        //ControllerContext
        public Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 200;
            context.HttpContext.Response.ContentType = "text/html";

            byte[] content = Encoding.ASCII.GetBytes(Content);
            return context.HttpContext.Response.Body.WriteAsync(content,0,content.Length);
        }
    }
}
