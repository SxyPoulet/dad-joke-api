using DadJokeApi.Models;
using DadJokeApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IJokeService _jokeService;

    public Joke Joke { get; private set; } = new();

    public IndexModel(IJokeService jokeService)
    {
        _jokeService = jokeService;
    }

    public void OnGet()
    {
        Joke = _jokeService.GetRandomJoke();
    }

    [ValidateAntiForgeryToken] // 👈 Add this
    public IActionResult OnPost()
    {
        Joke = _jokeService.GetRandomJoke();
        return Page();
    }
}
