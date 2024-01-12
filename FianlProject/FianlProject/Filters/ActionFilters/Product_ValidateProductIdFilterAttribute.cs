using System;
using FianlProject.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace FianlProject.Filters.ActionFilters
{
	public class Product_ValidateProductIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var productId = context.ActionArguments["id"] as int?;
            if (productId.HasValue)
            {

                if (productId.Value <= 0)
                {
                    context.ModelState.AddModelError("ProductId", "ProductId is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!ProductRepository.ProductExists(productId.Value))
                {
                    context.ModelState.AddModelError("ProductId", "ProductId does not exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
    }
}

