using FastEndpoints;

namespace no.sanddata.ams.Api.Features.WeatherForecast;

public sealed class GetWeatherForecastEndpoint : EndpointWithoutRequest<WeatherForecastResponse[]>
{
    public override void Configure()
    {
        Get("/weatherforecast");
        AllowAnonymous();
    }

#pragma warning disable CA5394 // Do not use insecure randomness
    public override async Task HandleAsync(CancellationToken ct)
    {
        string[] summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        WeatherForecastResponse[] forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecastResponse(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            )).ToArray();

        await Send.OkAsync(forecast, ct);
    }
#pragma warning restore CA5394
}

public sealed record WeatherForecastResponse(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
