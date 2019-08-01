using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text;

namespace Filters.Infrastructure
{
    //Класс с реализацией фильтра действий
    public class ProfileAttribute:ActionFilterAttribute
    {

        #region Реализация гибридного фильра - фильтра действий и результата

        private Stopwatch timer;
        private double actionTime;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();

            actionTime = timer.Elapsed.TotalMilliseconds;
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            timer.Stop();
            string result = "<div>Action time:" + $"{actionTime} ms </div><div> Total time: "
                + $"{timer.Elapsed.TotalMilliseconds} ms</div>";
            byte[] bytes = Encoding.ASCII.GetBytes(result);
            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }


        //Метод вызывается сразу после обработки запроса методом действия
        /* public override void OnActionExecuted(ActionExecutedContext context)
         {
             timer.Stop();
             string result = "Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms";
             byte[] bytes = Encoding.ASCII.GetBytes(result);
             context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
         }*/

        #endregion

        #region Реализация фильтра действий

        /*private Stopwatch timer;

        //Метод вызывается перед вызовом метода действия
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
           

        //Метод вызывается сразу после обработки запроса методом действия
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = "Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms";
            byte[] bytes = Encoding.ASCII.GetBytes(result);
            context.HttpContext.Response.Body.WriteAsync(bytes,0, bytes.Length);
        }*/

        #endregion
    }
}
