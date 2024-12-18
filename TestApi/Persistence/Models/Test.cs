using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestApi.Persistence.Models;

public class Test
{
    public Test(Domain.Models.Test test) : this(test.Id, test.Identifier)
    {
    }

    public Test(int id, string identifier)
    {
        Id = id;
        Identifier = identifier;
    }

    [Key]
    public int Id { get; set; }

    private string? _identifier;
    private long? _identifierNumber;

    public string Identifier

    {
        get => _identifier!;
        set
        {
            _identifier = value;
            _identifierNumber = long.TryParse(value, out var result) ? result : null;
        }
    }

    [JsonIgnore]
    public long? IdentifierNumber => _identifierNumber;
}