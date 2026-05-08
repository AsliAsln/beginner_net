using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using Microsoft.VisualBasic;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapgamesEndpoints();
app.Run();
