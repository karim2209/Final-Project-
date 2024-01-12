using System;
using FianlProject.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FianlProject.Filters.ExceptionFilters
{
	public class Product_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strProductId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strProductId, out int productId))
            {
                if (!ProductRepository.ProductExists(productId))
                {
                    context.ModelState.AddModelError("productId", "Product does not exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}

