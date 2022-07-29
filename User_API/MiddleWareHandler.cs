using Microsoft.AspNetCore.Builder;
using System.Linq;

namespace User_API
{
    public static class MiddleWareHandler
        {
        public static void UseMiddleWareEx(this IApplicationBuilder app)
        {
            app.UseMiddleware<MiddleWareExeption>();
        }
    } 
}
