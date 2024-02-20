namespace Shiptech.Application.Services;

public interface IIsoReadService
{
    Task<bool> ExistsById(string id);
}