using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

private static readonly List<GameDto> games = [
    new (1,
    "Street Fighter II",
    "Fighting",
    19.99m,
    new DateOnly(1992, 7, 15)),

    new (2,
    "GTA 5",
    "Action",
    29.99m,
    new DateOnly(2013, 9, 17)),
    new (3,
    "Minecraft",
    "Sandbox",
    26.95m,
    new DateOnly(2011, 11, 18))
];
public static void MapgamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");
 //GET /games
group.MapGet("/", () => games);


//GET /games/{id}
group.MapGet("/{id}", (int id) => 
{
    var game = games.Find(game=>game.Id ==id);
    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);

//POST /games
group.MapPost("/", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new{id = game.Id}, game);
});

//PUT /games/{id}
group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game=>game.Id == id);

    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

//DELETE /games/{id}
       group.MapDelete("/{id}", (int id) =>
       {
           games.RemoveAll(game => game.Id == id);
           return Results.NoContent();
       });
    }
}
