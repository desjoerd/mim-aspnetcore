# Middleware Pipeline

### Continue on dotnet-new demo

* Recap program.cs and startup.cs
* Do a dotnet restore and run

---
Add dotnet watch `mimToolsWatch`
```
"Microsoft.DotNet.Watcher.Tools": {
      "version": "1.0.0-*",
      "imports": "portable-net451+win8"
    }
```
Do a dotnet restore

---
* run `dotnet watch`
* Edit Startup.cs, show commandline and result in browser

---
* duplicate Hello World in Startup.cs
* (optional) Ask: what can we expect
* Show browser, same result because of not calling next
* Modify the first to be async and call next
* Modify the last to output `Hello from the end of the pipeline`
```
app.Use(async (context, next) => {
    await context.Response.WriteAsync("Hello World!\n");
    
    await next();
});

app.Use((context, next) => {
    return context.Response.WriteAsync("Hello from the end of the pipeline!\n");
});
```
* Show the result in the browser

---
### if middleware
* Add new middleware `mimMiddlewareBase` (optional ->) with an `if(context.Request.Path == "/mim")`
* Show the result in browser for `localhost:5000` and `localhost:5000/mim`

---
### Way back
* Add context writes after the `await next()`
* Show result in the browser

### Static Files
Now we want to do something usefull, like serving files

* Add staticfiles in project.json `mimStaticFiles`
* Tell about wwwroot
* Add wwwroot with an index.html
* Add static files to Startup as the first middleware
* Open browser and go to `/index.html`. Nothing changed!
* (optional) ask why
* because of the app runs in the bin folder
* Add `UseContentRoot(Directory.GetCurrentDirectory())` to Program.cs
* Refresh browser, TADAAA!

---
### Optional StatusCodePages
* Remove all context-writes
* Show what happens when navigating to `/` or `/bla`
* Add `Microsoft.AspNetCore.Diagnostics` to project.json
* Add `app.UseStatusCodePagesWithRedirects("/{0}.html");` to Startup.cs
* Add 404.html in WWWRoot
* Show result
* (optional) Change statusCode pages in `app.UseStatusCodePagesWithReExecute("/{0}.html");`
* Show result

---
End of demo
