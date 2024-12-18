using Microsoft.AspNetCore.Mvc;

namespace TestApi;

public static class GenericEndpoints
{
    public static void AddGenericEndpoint(this WebApplication app)
    {
        app.MapPost("/test",
                async () => { })
            .WithName("TestGenericOrchestrator")
            .WithOpenApi();
    }
}