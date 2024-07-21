namespace Shiptech.Application.Services;

public interface IDrawingReadService
{
    Task<bool> ExistsById(Ulid id);
}