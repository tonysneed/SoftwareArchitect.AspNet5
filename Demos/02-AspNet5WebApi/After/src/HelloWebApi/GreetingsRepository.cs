using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWebApi
{
    public class GreetingsRepository : IGreetingsRepository
    {
        private readonly List<string> _greetings = new List<string>
        {
            "Hello", "Howdy", "Aloha", "Yo", "Ciao"
        };

        public async Task<string> GetGreetingAsync(int id)
        {
            return await Task.FromResult(_greetings[id - 1]);
        }
    }
}