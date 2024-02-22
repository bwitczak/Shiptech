using Shiptech.Application.Dtos;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.Queries;

internal static class Extensions
{
    public static ShipDto AsDto(this ShipReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Orderer = readModel.Orderer
        };
}