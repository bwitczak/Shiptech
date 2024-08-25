namespace Shiptech.Application.Common.Interfaces.Services;

public interface IChemicalProcessService
{
    Task<bool> ExistsById(Ulid id);
}
