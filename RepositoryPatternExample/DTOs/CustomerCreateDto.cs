using System;
namespace RepositoryPatternExample.DTOs
{
	public record struct CustomerCreateDto(string Name,
        string FirstName,
        string LastName,
        string Place,
        List<CreateAddressDto> Addresses);
}

