using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.AssortmentDictionary.Commands.CreateAssortmentDictionary;
using Shiptech.Application.AssortmentDictionary.Commands.DeleteAssortmentDictionary;
using Shiptech.Application.AssortmentDictionary.Commands.UpdateAssortmentDictionary;
using Shiptech.Application.AssortmentDictionary.Queries.SearchAssortmentDictionaries;
using Shiptech.Application.Common.Models.AssortmentDictionary;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class AssortmentDictionaries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(SearchAssortmentDictionaries, "/Search")
            .MapPost(CreateAssortmentDictionary, "/Create")
            .MapPut(UpdateAssortmentDictionary, "/Update/{id}")
            .MapDelete(DeleteAssortmentDictionary, "/Delete/{id}");
    }

    private Task<IEnumerable<AssortmentDictionaryDto>> SearchAssortmentDictionaries(ISender sender,
        [AsParameters] SearchAssortmentDictionariesQuery query)
    {
        return sender.Send(query);
    }

    private Task CreateAssortmentDictionary(ISender sender, [FromBody] CreateAssortmentDictionaryCommand command)
    {
        return sender.Send(command);
    }

    private Task UpdateAssortmentDictionary(ISender sender, Ulid id,
        [FromBody] UpdateAssortmentDictionaryCommand command)
    {
        return sender.Send(command);
    }

    private Task DeleteAssortmentDictionary(ISender sender, Ulid id,
        [FromBody] DeleteAssortmentDictionaryCommand command)
    {
        return sender.Send(command);
    }
}
