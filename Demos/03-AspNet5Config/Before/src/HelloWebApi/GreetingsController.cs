using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace HelloWebApi
{
    [Route("api/[controller]")]
    public class GreetingsController : Controller
    {
        private readonly IGreetingsRepository _greetingsRespository;
        //private readonly IOptions<GreetingOptions> _greetingOptions;

        public GreetingsController(IGreetingsRepository greetingsRespository)
        {
            _greetingsRespository = greetingsRespository;
            //_greetingOptions = greetingOptions;
        }

        // GET: api/greetings
        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var region = string.Empty; //_greetingOptions.Options.Region;
            string greeting = await _greetingsRespository.GetGreetingAsync(region);
            return new HttpOkObjectResult(greeting);
        }

        // GET: api/greetings/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            string greeting = await _greetingsRespository.GetGreetingAsync(id);
            return new HttpOkObjectResult(greeting);
        }
    }
}
