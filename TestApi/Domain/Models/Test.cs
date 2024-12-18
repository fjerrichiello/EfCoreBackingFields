namespace TestApi.Domain.Models;

public record Test(int Id, string Identifier)
{
    public Test(TestEntity entity) : this(entity.Id, entity.Identifier)
    {
    }
};