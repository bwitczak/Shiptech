namespace Shiptech.Application.Services;

public interface IAssortmentReadService
{
    Task<bool> ExistsById(string id);
}