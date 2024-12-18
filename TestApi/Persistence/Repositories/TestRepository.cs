using Microsoft.EntityFrameworkCore;
using TestApi.Domain.Models;

namespace TestApi.Persistence.Repositories;

public class TestRepository(ApplicationDbContext _context) : ITestRepository
{
    public async Task<Test?> GetAsync(int id)
    {
        var entity = await _context.Tests.FindAsync(id);

        return entity is null ? null : new Test(entity);
    }

    public async Task<List<TestDto>> GetAllAsync()
    {
        var results = await _context.Tests.ToListAsync();

        return results.Select(x => new TestDto(x)).ToList();
    }


    public async Task AddAsync(Test test)
        => await _context.Tests.AddAsync(new(test));
}