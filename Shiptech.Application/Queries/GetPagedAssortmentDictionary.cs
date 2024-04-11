using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetPagedAssortmentDictionary : IQuery<IEnumerable<AssortmentDictionaryDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}