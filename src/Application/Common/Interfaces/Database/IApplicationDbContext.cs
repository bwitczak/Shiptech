using Microsoft.EntityFrameworkCore;
using Shiptech.Domain.Entities;

namespace Shiptech.Application.Common.Interfaces.Database;

public interface IApplicationDbContext
{
    DbSet<Ship> Ships { get; }
    DbSet<Drawing> Drawings { get; }
    DbSet<Iso> Isos { get; }
    DbSet<Assortment> Assortments { get; }
    DbSet<ChemicalProcess> ChemicalProcesses { get; }
    DbSet<Domain.Entities.AssortmentDictionary> AssortmentDictionaries { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
