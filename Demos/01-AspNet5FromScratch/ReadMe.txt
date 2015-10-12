ASP.NET 5 From Scratch on Windows

The purpose of this demo is to illustrate architectual aspects of ASP.NET 5
by creating a new Web API app from scratch on Windows using a text editor
and the DNX command-line tools.

Instructions for getting started with ASP.NET 5 can be found here:
https://github.com/aspnet/Home

Part A: Install latest DNX

1. Run the following from an elevated command prompt:
   @powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';$wc=New-Object System.Net.WebClient;$wc.Proxy=[System.Net.WebRequest]::DefaultWebProxy;$wc.Proxy.Credentials=[System.Net.CredentialCache]::DefaultNetworkCredentials;Invoke-Expression ($wc.DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"
   
   
2. Install the latest DNX runtime by executing the following:
   dnvm upgrade -a x86 -r clrcore
   dnvm upgrade -a x64 -r clrcore
   dnvm upgrade -a x86
   dnvm upgrade -a x64
   
3. Then show the installed runtimes by executing:
   dnvm list
   
   - It should show the installed DNX runtimes
   
Part B: Console App from Scratch

1. Open File Explorer and navigate to the ConsoleApp folder in the Before directory
   - Add a project.json file with the following content:
   
  {
    "frameworks": {
      "dnx451": { },
      "dnxcore50": {
        "dependencies": {
          "System.Console": "4.0.0-beta-23225"
        }
      }
    }
  }

2. Add a program.cs file with the following content:

using System;

  class Program
  {
      static void Main()
      {
          Console.WriteLine("Hello ASP.NET 5!");
      }
  }

3. Open a command prompt at the location and enter the following commands
   dnu restore
   
   - This restores nuget packages specified in project.json
   
   dnx run
   
   - This executes the app entry point
   - You can also specify app name: ConsoleApp (ie, the folder name)
   
4. Set version to x64 coreclr and re-execute both commands:
   dnu restore
   dnx run
   
Part C: Web App from Scratch

1. Add a project.json file to the WebApp folder with the following content:

  {
    "dependencies": {
          "Microsoft.AspNet.Server.Kestrel": "1.0.0-beta7",
          "Microsoft.AspNet.Diagnostics": "1.0.0-beta7",
          "Microsoft.AspNet.Hosting": "1.0.0-beta7",
          "Microsoft.AspNet.Server.WebListener": "1.0.0-beta7"
      },
      "commands": {
          "web": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.WebListener --server.urls http://localhost:5001",
          "kestrel": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.Kestrel --server.urls http://localhost:5004"
      },
      "frameworks": {
          "dnx451": { },
          "dnxcore50": { }
      }
  }

2. Add a startup.cs class with the following content:

  using Microsoft.AspNet.Builder;

  namespace HelloWeb
  {
      public class Startup
      {
          public void Configure(IApplicationBuilder app)
          {
              app.UseWelcomePage();
          }
      }
  }

3. Open a command prompt at the WebApp folder and execute:
   dnu restore
   dnx web
   
   - The web listener should start
   
4. Open a browser at the following location:
   http://localhost:5001
   
   - You should see a welcome page
   
   