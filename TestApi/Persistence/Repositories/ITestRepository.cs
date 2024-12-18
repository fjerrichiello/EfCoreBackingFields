using TestApi.Domain.Models;

namespace TestApi.Persistence.Repositories;

public interface ITestRepository
{
    Task<Test?> GetAsync(int id);
    
    Task<List<TestDto>> GetAllAsync();

    Task AddAsync(Test test);
}