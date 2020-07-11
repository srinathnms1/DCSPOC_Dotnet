namespace Fuel.Api.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Net;
    using Fuel.Api.Infrastructure.HttpErrors;

    public class ValidModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var validationErrors = context.ModelState
                .Keys
                .SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.Exception.Message)
                .ToArray();

            var error = HttpError.CreateHttpValidationError(
                status: HttpStatusCode.BadRequest,
                userMessage: new[] { "There are validation errors" },
                validationErrors: validationErrors);

            context.Result = new BadRequestObjectResult(error);
        }
    }
}
