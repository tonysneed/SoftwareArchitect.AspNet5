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

        private readonly Dictionary<string, string> _regionalGreetings = new Dictionary<string, string>
        {
            ["Default"] = "Hello",
            ["London"] = "Good Day",
            ["Rome"] = "Ciao",
            ["Bratislava"] = "Ahoj",
            ["Dallas"] = "Howdy",
            ["New York"] = "Yo",
            ["Los Angeles"] = "Dude",
            ["Hawaii"] = "Aloha",
        };

        public async Task<string> GetGreetingAsync(int id)
        {
            return await Task.FromResult(_greetings[id - 1]);
        }

        public async Task<string> GetGreetingAsync(string region)
        {
            if (string.IsNullOrWhiteSpace(region)) return await Task.FromResult(_regionalGreetings["Default"]);
            string greeting;
            _regionalGreetings.TryGetValue(region, out greeting);
            return await Task.FromResult(greeting);
        }
    }
}