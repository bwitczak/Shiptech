namespace Shiptech.Application.Common.Interfaces.Services;

public interface IIsoService
{
    Task<bool> ExistsById(Ulid id);
}
