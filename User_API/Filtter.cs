using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace User_API
{
    public class Filtter : Attribute, IActionFilter
    {
        private string key;
        public Filtter( string key)
        {
            this.key = key;
        }

    //implement the synchronous Action filter that runs before and after action method execution
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.HttpContext.Request.Headers["Role"];
            if (param == key)
            {
                return;
            }
            else
            {
                context.Result = new BadRequestObjectResult(" *** Wrong Key ***");
                return;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
       
    }
}



      