ASP.NET 5 Config ReadMe

This sample demonstrates how to use environment variables with the
new configuration system in ASP.NET 5.

1. Note that GreetingRepository supports regional greetings
   - There is also a GreetingOptions class with a Region property

2. Update code in the GreetingsController to set a _greetingOptions field
   from the constructor.

    public GreetingsController(IGreetingsRepository greetingsRespository,
        IOptions<GreetingOptions> greetingOptions)
    {
        _greetingsRespository = greetingsRespository;
        _greetingOptions = greetingOptions;
    }

   - In the Get() action, set region to _greetingOptions.Options.Region

3. In the Startup class, uncomment the Configuration property

	public IConfiguration Configuration { get; set; }

   - In the ctor, uncomment code which sets the Configuration property

    Configuration = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();

   - In the ConfigureServices method, uncomment code to configure GreetingOptions
     by setting GreetingOptions.Region from Region environment variable
	 on the Configuration property.

	services.Configure<GreetingOptions>(o => o.Region = Configuration["Region"]);

4. Add code to Startup.ConfigureServices for registering the repository
   with DI

	services.AddScoped<IGreetingsRepository, GreetingsRepository>();

5. Open a command prompt at the src\HelloWebApi directory,
   then execute the following commands:

   dnvm list
     - Verify teh active DNX version
   dnu restore
     - Will download necessary NuGet packages based on dependencies in project.json

6. Set the Region environment variable to one of the regions listed in GreetingsRepository
   - For example:

	set Region=Los Angeles

   - Then start the web app:

   dnx web
     - Will start web listener on specified port (see hosting.ini file)
   
7. Open a browser and navigate to: http://localhost:5001/api/greetings
    - You should see the regional greeting displayed
    - Press Ctrl+C to shut down the web listener
    
    