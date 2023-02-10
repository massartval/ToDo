using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ToDo.Models;

namespace ToDo.Tools
{
    public class ExceptionFilter : IFilterMetadata
    {
        private readonly IHostEnvironment _hostEnvironment;
        public ExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void OnException(ExceptionContext context) 
        {
            ErrorViewModel errorViewModel = new ErrorViewModel() { ErrorMessage = context.Exception.Message };

            if (!_hostEnvironment.IsDevelopment())
            {
                errorViewModel.ErrorMessage = "Something went wrong...";
            }

            ViewResult result = new ViewResult() { ViewName = "ShowError" };
            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);
            result.ViewData.Model = errorViewModel;

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
