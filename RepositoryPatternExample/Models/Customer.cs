﻿using System.Text.Json.Serialization;

namespace RepositoryPatternExample.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Place { get; set; } = string.Empty;

    public List<Address>? Address { get; set; }

}

