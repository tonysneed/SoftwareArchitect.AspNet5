using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;

namespace HelloWebApi
{
    public class Startup
    {
        // Configuration property
        //public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Add configuration sources
            //Configuration = new ConfigurationBuilder()
            //    .AddEnvironmentVariables()
            //    .Build();
        }

        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure options
            //services.Configure<GreetingOptions>(o => o.Region = Configuration["Region"]);

            // Configure DI for MVC
            services.AddMvc();

            // Configure DI for repository
            services.AddScoped<IGreetingsRepository, GreetingsRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configure the pipeline to include MVC
            app.UseMvc();

            // Friendly welcome page
            app.UseWelcomePage();
        }
    }
}
