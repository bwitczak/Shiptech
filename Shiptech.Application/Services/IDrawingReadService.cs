namespace Shiptech.Application.Services;

public interface IDrawingReadService
{
    Task<bool> ExistsById(string id);
}