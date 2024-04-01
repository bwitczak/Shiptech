using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetPagedAssortmentDictionary : IQuery<IEnumerable<AssortmentDictionaryWithNoRelationsDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}