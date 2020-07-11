namespace Fuel.Api.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Mvc;

    public static class ControllerBaseExtensions
    {
        public static string GetActionName(this ControllerBase baseController)
        {
            var routeDateValues = baseController.RouteData.Values;
            if (routeDateValues.ContainsKey("action"))
            {
                return (string)routeDateValues["action"];
            }
            return string.Empty;
        }
        public static string GetControllerName(this ControllerBase baseController)
        {
            var routeDateValues = baseController.RouteData.Values;
            if (routeDateValues.ContainsKey("controller"))
            {
                return (string)routeDateValues["controller"];
            }
            return string.Empty;
        }
    }
}
