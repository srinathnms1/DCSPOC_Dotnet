namespace Fuel.Api.Helpers.Binders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Threading.Tasks;
    using static Fuel.Contracts.Constants;
    using System.Globalization;

    public class DateTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                bindingContext.Result = ModelBindingResult.Success(false);
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName, $"{modelName} is required.");
                return Task.CompletedTask;
            }

            if (!DateTime.TryParseExact(value, DateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime result))
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName, $"Date must be of {DateFormat}.");

                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
