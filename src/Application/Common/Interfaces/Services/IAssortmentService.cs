namespace Shiptech.Application.Common.Interfaces.Services;

public interface IAssortmentService
{
    Task<bool> ExistsById(Ulid id);
}
