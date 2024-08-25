namespace Shiptech.Application.Common.Interfaces.Services;

public interface IAssortmentDictionaryService
{
    Task<bool> ExistsById(Ulid id);
}
