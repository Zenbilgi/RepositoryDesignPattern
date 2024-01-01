using System.Text.Json.Serialization;

namespace RepositoryPatternExample.Models;

public class Address
{
    public int Id { get; set; }

    public string Country { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int CustomerId { get; set; }

    [JsonIgnore]
    public Customer? Customer { get; set; }
}

