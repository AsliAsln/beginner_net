using GameStore.Api.Dtos;

const string GetGameEndpointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
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
 //GET /games
app.MapGet("/games", () => games);


//GET /games/{id}
app.MapGet("/games/{id}", (int id) => games.Find(game=>game.Id ==id))
.WithName(GetGameEndpointName);

//POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
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

//PUT /games/id
app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
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

//DELETE /games/id
       app.MapDelete("/games/{id}", (int id) =>
       {
           games.RemoveAll(game => game.Id == id);
           return Results.NoContent();
       });
app.Run();
