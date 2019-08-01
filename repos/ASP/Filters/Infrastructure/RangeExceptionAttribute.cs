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

    //Класс с реализацией фильтров исключений
    public class RangeExceptionAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException)
            {
                context.Result = new ViewResult()
                {
                    ViewName = "Message",
                    ViewData = new ViewDataDictionary(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                    {
                        Model = @"The data received by the application connot be processed"
                    }
                };
            }
        }
    }
}
