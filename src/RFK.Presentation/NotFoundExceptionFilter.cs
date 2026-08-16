using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RFK.Presentation
{
    public class NotFoundExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException ex)
            {
                context.Result = new NotFoundObjectResult(new ErrorDetails
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = ex.Message
                });

                context.ExceptionHandled = true; // Prevents exception from bubbling up
            }
        }
    }
}
