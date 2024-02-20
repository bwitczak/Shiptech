namespace Shiptech.Application.Services;

public interface IChemicalProcessReadService
{
    Task<bool> ExistsById(string id);
}