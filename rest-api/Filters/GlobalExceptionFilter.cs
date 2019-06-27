using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using rest_api.Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace rest_api.Filters
{
   public class GlobalExceptionFilter : IExceptionFilter
   {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;
            int code = 0;
            if (context.HttpContext.Request.Path.Value.StartsWith("/api"))
            {
                var exceptionType = context.Exception.GetType();
                String type = exceptionType.ToString();

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    message = "Unauthorized Access";
                    status = HttpStatusCode.Unauthorized;
                }
                else if (exceptionType == typeof(NotImplementedException))
                {
                    message = "A server error occurred.";
                    status = HttpStatusCode.NotImplemented;
                }
                else
                {
                    if (context.Exception.Message != null && context.Exception.Message.Length > 300)
                    {
                        message = context.Exception.Message.Substring(0, 299);
                    }
                    else
                    {
                        message = context.Exception.Message;
                    }


                    status = HttpStatusCode.BadRequest;
                }

                var result = new MsgException
                {
                    status = status,

                    message = message,

                    code = code,

                    type = type
                };

                context.Result = new ObjectResult(new MsgResult { exception = result });
            }

        }
   }
}
