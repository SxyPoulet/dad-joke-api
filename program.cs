using DadJokeApi.Models;
using DadJokeApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Swagger and Razor
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages(); // 👈 Razor support added
builder.Services.AddSingleton<IJokeService, JokeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages(); // 👈 Razor routing
app.MapGet("/", context =>
{
    context.Response.Redirect("/Index");
    return Task.CompletedTask;
});

// Optional API routes
app.MapGet("/joke/random", (IJokeService jokeService) =>
{
    var joke = jokeService.GetRandomJoke();
    return Results.Ok(joke);
});

app.MapGet("/joke/all", (IJokeService jokeService) =>
{
    var jokes = jokeService.GetAllJokes();
    return Results.Ok(jokes);
});

app.MapPost("/joke", (Joke joke, IJokeService jokeService) =>
{
    jokeService.AddJoke(joke);
    return Results.Created($"/joke/{joke.Id}", joke);
});

app.Run();
