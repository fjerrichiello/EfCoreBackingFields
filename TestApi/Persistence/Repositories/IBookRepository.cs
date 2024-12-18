using TestApi.Domain.Models;

namespace TestApi.Persistence.Repositories;

public interface IBookRepository
{
    Task<Book?> GetAsync(int id);

    Task AddAsync(Book book);
}