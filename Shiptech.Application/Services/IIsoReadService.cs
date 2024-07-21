namespace Shiptech.Application.Services;

public interface IIsoReadService
{
    Task<bool> ExistsById(Ulid id);
}