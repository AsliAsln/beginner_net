using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using Microsoft.VisualBasic;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.MapgamesEndpoints();

app.Run();
