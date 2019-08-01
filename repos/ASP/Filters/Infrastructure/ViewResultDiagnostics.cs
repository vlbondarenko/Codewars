using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ViewResultDiagnostics:IActionFilter
    {
        private IFilterDiagnosics diagnostics;
        public ViewResultDiagnostics(IFilterDiagnosics diags)
        {
            diagnostics = diags;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //ничего не делать - метод в этом фильтре не используется
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            ViewResult vr;
            if ((vr = context.Result as ViewResult) != null)
            {
                diagnostics.AddMessage($"View name : {vr.ViewName}");
                diagnostics.AddMessage($@"Model type: {vr.ViewData.Model.GetType().Name}");
            }
        }
    }
}
