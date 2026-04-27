namespace GameStore.Api.Dtos;

public record UpdateGameDto
(
    String Name,
    String Genre,
    decimal Price,
    DateOnly ReleaseDate
);