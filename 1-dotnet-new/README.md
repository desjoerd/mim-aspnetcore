1.	Open Terminal window and show dotnet –help
2.	Shortly explain new, restore, build, publish, etc
3.	Navigate to folder documents cd documents
4.	Create a new folder with mkdir demo1 and cd demo1
5.	Create new project with dotnet new
6.	List folder contents with ls and explain Project.json and Program.cs
7.	Restore dependencies with dotnet restore
8.	Build project with dotnet build
9.	Run project with dotnet run
10.	 Open project in Visual Studio Code by typing code . (public preview may 2015, beta November 2015 and 1.0 april 2016)
11.	 Click “Yes” to add assets (.vscode folder tasks and launch)
12.	 No csproj, view matches filesystem
13.	Build project in VS Code using Shift + Cmd + b
14.	Open project.json and explain sections
15.	Add a framework “net451”
16.	 Do a restore in VS Code using F1 and it fails  Explain why you can target .NET 4.5.1 but not on OS X. Fix with correct project.json
17.	 Show debug output in Terminal Window
18.	We’re changing the project output from shared to standalone
19.	Open project.json and add
```
"runtimes": {
    "osx.10.11-x64"
}
```
20.	And remove the `"type": "platform"` line
21.	Restore dependencies with dotnet restore
22.	Build project with dotnet build
23.	Navigate to /bin/Debug/netcoreapp1.0/osx.10.11-x64
24.	And execute the standalone program with ./demo1
25.	Make the project Shared again
26.	Add Kestrel dependency in Project.json using snippet (mim_kestrel)
27.	Using F1 do a dotnet restore
28.	Add new file Startup.cs with snippet (mim_startup)
29.	Update program.cs with snippet (mim_program)
30.	Build program with CMD + Shift + B
31.	Debug using F5
32.	Add logging dependency with snippet (mim_diagnostics)
33.	Add runtime info page: app.UseRuntimeInfoPage();
34.	Navigate within to browser http://localhost:5000/runtimeinfo
35. Next add dependency `"Microsoft.AspNetCore.Server.Kestrel": "1.0.0-*",`
36. Add `Startup.cs`

```
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
```

37. And update `Program.cs`
```
var host = new WebHostBuilder()
                        .UseKestrel()
                        .UseStartup<Startup>()
                        .Build();

            host.Run();
```