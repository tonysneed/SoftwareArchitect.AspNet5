using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;

namespace HelloWebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure DI for MVC
            services.AddMvc();

            // Configure DI for repository
            services.AddScoped<IGreetingsRepository, GreetingsRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configure the pipeline to include MVC
            app.UseMvc();

            app.UseWelcomePage();
        }
    }
}
