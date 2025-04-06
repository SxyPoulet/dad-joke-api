using DadJokeApi.Models;

namespace DadJokeApi.Services;

public interface IJokeService
{
    Joke GetRandomJoke();
    IEnumerable<Joke> GetAllJokes();
    void AddJoke(Joke joke);
}
