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
            // TODO: Configure DI for MVC
            //services.AddMvc();

            // TODO: Configure DI for repository
            //services.AddScoped<IGreetingsRepository, GreetingsRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            // TODO: Configure the pipeline to include MVC
            //app.UseMvc();

            app.UseWelcomePage();
        }
    }
}
