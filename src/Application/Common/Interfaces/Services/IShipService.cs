namespace Shiptech.Application.Common.Interfaces.Services;

public interface IShipService
{
    Task<bool> ExistsById(Ulid id);
    Task<bool> ExistsByCode(string code);
    Task<bool> ExistsByOrderer(string orderer);
}
