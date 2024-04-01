namespace Shiptech.Application.Services;

public interface IAssortmentDictionaryReadService
{
    Task<bool> ExistsById(Guid id);
}