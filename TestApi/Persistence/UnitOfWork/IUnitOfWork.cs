namespace TestApi.Persistence.UnitOfWork;

public interface IUnitOfWork
{
    Task CompleteAsync();
}