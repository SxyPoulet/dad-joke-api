namespace DadJokeApi.Models;

public class Joke
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Setup { get; set; } = string.Empty;
    public string Punchline { get; set; } = string.Empty;
}
