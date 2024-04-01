using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetAssortmentDictionary : IQuery<AssortmentDictionaryWithNoRelationsDto>
{
    public Guid Id { get; set; }
}