using System.Threading.Tasks;

namespace HelloWebApi
{
    public interface IGreetingsRepository
    {
        Task<string> GetGreetingAsync(int id);

        Task<string> GetGreetingAsync(string region);
    }
}