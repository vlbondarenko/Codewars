using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace Filters.Infrastructure
{

    //Класс фильтра результата действия
    public class ViewResultDetailsAttribute:ResultFilterAttribute
    {
       
        #region Реализация синхронного метода фильтра результата действия

        //Метод выполняется после отработки метода действия но до того как результат метода действия
        //будет обработан инфраструктурой Mvc для генерации представления
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                ["Result Type"] = context.Result.GetType().Name
            };

            ViewResult vr;

            if((vr=context.Result as ViewResult) != null)
            {
                dict["View Name"] = vr.ViewName;
                dict["Model type"] = vr.ViewData.Model.GetType().Name;
                dict["Model Data"] = vr.ViewData.Model.ToString();
            }
            context.Result = new ViewResult
            {
                ViewName = "Message",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                { Model = dict }
            };
        }

        #endregion

        #region Реализация синхронного метода фильтра результата действия

        public override async Task OnResultExecutionAsync(ResultExecutingContext context,ResultExecutionDelegate next)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                ["Result Type"] = context.Result.GetType().Name
            };

            ViewResult vr;

            if ((vr = context.Result as ViewResult) != null)
            {
                dict["View Name"] = vr.ViewName;
                dict["Model type"] = vr.ViewData.Model.GetType().Name;
                dict["Model Data"] = vr.ViewData.Model.ToString();
            }
            context.Result = new ViewResult
            {
                ViewName = "Message",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                { Model = dict }
            };

            await next();
        }

        #endregion
    }
}
