using TestApi.Persistence.Repositories;

namespace TestApi;

public static class GenericEndpoints
{
    public static void AddGenericEndpoint(this WebApplication app)
    {
        app.MapGet("/get-author",
                async (IAuthorRepository _authorRepository) => await _authorRepository.GetAsync(1))
            .WithName("TestGenericOrchestratorGet")
            .WithOpenApi();
    }
}