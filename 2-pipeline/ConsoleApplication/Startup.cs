using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app) {
            app.UseRuntimeInfoPage();
            
            app.UseStaticFiles();
            
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("Hello world!\n");
                
                await next();
                
                await context.Response.WriteAsync("Bye world!\n");
            });
            
            app.Use(async (context, next) => {
                // Try this url and figure out what the output will be ^^.
                if(context.Request.Path == "/secret") {
                    await context.Response.WriteAsync("Secret message\n");
                }
                else {
                    await next();
                }
            });
            
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("Hello AspNetCore!\n");
                
                await next();
                
                await context.Response.WriteAsync("Bye AspNetCore!\n");
            });
            
            app.Run((context) => context.Response.WriteAsync("Hello from the end of the pipeline!\n"));
        }
    }
}