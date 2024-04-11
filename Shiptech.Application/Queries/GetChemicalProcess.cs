using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetChemicalProcess : IQuery<ChemicalProcessDto>
{
    public Guid Id { get; set; }
}