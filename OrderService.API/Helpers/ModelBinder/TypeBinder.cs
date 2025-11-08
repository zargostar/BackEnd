using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace OrderService.API.Helpers.ModelBinder
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {



            var propertyName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(propertyName);
            if (value == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            else
            {
                try
                {
                    var result = JsonConvert.DeserializeObject<T>(value.FirstValue);
                    bindingContext.Result = ModelBindingResult.Success(result);


                }
                catch (Exception)
                {
                    bindingContext.ModelState.TryAddModelError(propertyName, "The Given Value Is Not Valid");

                }

            }
            return Task.CompletedTask;

        }
    }
}
