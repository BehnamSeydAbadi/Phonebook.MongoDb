using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.ViewModels;

namespace WebAPI.Infrastructure.Filters
{
    public class OutputActionFilter : IActionFilter
    {
        public static OutputActionFilter Instance => new OutputActionFilter();

        private OutputActionFilter() { }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is not null)
                return;

            var result = context.Result as ObjectResult;

            result.Value = new OutputViewModel { Data = result.Value };

            context.Result = result;
        }
    }
}
