using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Filter
{
    public class LoggingActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.Write("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.Write("OnActionExecuting");
        }
    }
}
