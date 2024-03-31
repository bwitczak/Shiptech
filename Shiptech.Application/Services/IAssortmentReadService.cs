namespace Shiptech.Application.Services;

public interface IAssortmentReadService
{
    Task<bool> ExistsById(Guid id);
}