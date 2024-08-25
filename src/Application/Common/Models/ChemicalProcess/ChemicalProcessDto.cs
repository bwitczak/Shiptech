using AutoMapper;
using Shiptech.Application.Common.Models.Drawing;

namespace Shiptech.Application.Common.Models.ChemicalProcess;

public class ChemicalProcessDto
{
    public Ulid Id { get; set; }
    public required string ChemicalProcessCode { get; set; }
    public required string ChemicalProcessName { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.ChemicalProcess, ChemicalProcessDto>();
        }
    }
}
