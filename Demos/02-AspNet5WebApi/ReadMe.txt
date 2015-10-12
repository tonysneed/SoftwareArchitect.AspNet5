ASP.NET 5 Web API ReadMe

This sample demonstrates how to build a Web API using ASP.NET 5 with MVC 6.
The Before solution has a starter project which includes a controller that
depends on a repository interface for retrieving greetings.

1. Note the addition of MVC as a dependency in project.json

	"Microsoft.AspNet.Mvc": "6.0.0-beta7"

2. Add code to Startup.Configure for using MVC in the pipeline

	app.UseMvc();

3. Add code to Startup.ConfigureServices for registering MVC with DI

	services.AddMvc();

4. Add code to Startup.ConfigureServices for registering the repository
   with DI

	services.AddScoped<IGreetingsRepository, GreetingsRepository>();

5. Open a command prompt at the src\HelloWebApi directory,
   then execute the following commands:
   dnvm list
     - Verify teh active DNX version
   dnu restore
     - Will download necessary NuGet packages based on dependencies in project.json
   dnx web
     - Will start web listener on specified port (see hosting.ini file)
   
 6. Open a browser and navigate to: http://localhost:5001/api/greetings/1
    - You should see the first greeting displayed
    - Supply difference id's (1-5) to see different greetings 
    - Press Ctrl+C to shut down the web listener
    
    