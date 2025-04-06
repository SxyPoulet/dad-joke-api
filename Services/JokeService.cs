using DadJokeApi.Models;

namespace DadJokeApi.Services;

public class JokeService : IJokeService
{
    private readonly List<Joke> _jokes = new()
    {
        new Joke { Setup = "Why do programmers prefer dark mode?", Punchline = "Because light attracts bugs." },
        new Joke { Setup = "Why did the developer go broke?", Punchline = "Because he used up all his cache." },
        new Joke { Setup = "How many programmers does it take to change a light bulb?", Punchline = "None. It is a hardware problem." },
    };

    public Joke GetRandomJoke()
    {
        var random = new Random();
        return _jokes[random.Next(_jokes.Count)];
    }

    public IEnumerable<Joke> GetAllJokes() => _jokes;

    public void AddJoke(Joke joke)
    {
        _jokes.Add(joke);
    }
}
