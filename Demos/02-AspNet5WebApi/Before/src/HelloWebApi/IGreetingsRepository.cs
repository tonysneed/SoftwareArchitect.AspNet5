using System.Threading.Tasks;

public interface IGreetingsRepository
{
    Task<string> GetGreetingAsync(int id);
}