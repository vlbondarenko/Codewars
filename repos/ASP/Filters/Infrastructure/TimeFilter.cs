using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    
    //Пример класса фильтра с внедрением зависимостей
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private ConcurrentQueue<double> actionTimes = new ConcurrentQueue<double>();    //Переменные для хранения времени
        private ConcurrentQueue<double> resultTimes = new ConcurrentQueue<double>(); 
        private Stopwatch timer;
        private IFilterDiagnosics diagnosics;

        public TimeFilter(IFilterDiagnosics diagnosics)
        {
            this.diagnosics = diagnosics;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            actionTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            diagnosics.AddMessage($@"Action time : {timer.Elapsed.TotalMilliseconds}
            Average: {actionTimes.Average():F2}");
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            resultTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            diagnosics.AddMessage($@"Result time: {timer.Elapsed.TotalMilliseconds}
            Average:{resultTimes.Average():F2}");
        }

    }
}
