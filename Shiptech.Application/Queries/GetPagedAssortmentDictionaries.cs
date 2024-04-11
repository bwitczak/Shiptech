using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetPagedAssortmentDictionaries : IQuery<IEnumerable<AssortmentDictionaryDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}