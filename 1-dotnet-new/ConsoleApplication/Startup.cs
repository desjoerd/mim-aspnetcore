using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app) {
            
            app.UseRuntimeInfoPage();
            
            app.Use((context, next) => {
                return context.Response.WriteAsync("Hello world!\n");
            });
        }
    }
}