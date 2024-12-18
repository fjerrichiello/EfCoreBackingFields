namespace TestApi.Domain.Models;

public record TestDto(int Id, string Identifier, long IdentifierNumber)
{
    public TestDto(TestEntity entity) : this(entity.Id, entity.Identifier, entity.IdentifierNumber.Value)
    {
    }
};