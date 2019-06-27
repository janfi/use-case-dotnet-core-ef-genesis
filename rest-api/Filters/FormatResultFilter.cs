using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using rest_api.Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.Filters
{
    public class FormatResultFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.HttpContext.Request.Path.Value.StartsWith("/api"))
            {

                if (context.Exception == null)
                {
                    try
                    {
                        context.Result = new ObjectResult(new MsgResult { data = ((ObjectResult)context.Result).Value });
                    }
                    catch
                    {
                        // BAD ROUTE
                    }

                }

            }


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
