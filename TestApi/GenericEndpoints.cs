using Microsoft.AspNetCore.Mvc;
using TestApi.Domain.Models;
using TestApi.Persistence.Repositories;

namespace TestApi;

public static class GenericEndpoints
{
    public static void AddGenericEndpoint(this WebApplication app)
    {
        app.MapPost("/add-test",
                async (ITestRepository _testRepository) =>
                {
                    await _testRepository.AddAsync(new Test(Random.Shared.Next(1000000),
                        Random.Shared.Next(Int32.MaxValue).ToString()));
                })
            .WithName("TestGenericOrchestrator")
            .WithOpenApi();


        app.MapGet("/get-tests",
                async (ITestRepository _testRepository) => await _testRepository.GetAllAsync())
            .WithName("TestGenericOrchestratorGet")
            .WithOpenApi();
    }
}