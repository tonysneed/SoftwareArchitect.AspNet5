using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace HelloWebApi
{
    [Route("api/[controller]")]
    public class GreetingsController : Controller
    {
        private readonly IGreetingsRepository _greetingsRespository;

        public GreetingsController(IGreetingsRepository greetingsRespository)
        {
            _greetingsRespository = greetingsRespository;
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
