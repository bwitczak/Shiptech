namespace Shiptech.Application.Common.Interfaces.Services;

public interface IDrawingService
{
    Task<bool> ExistsById(Ulid id);
}
