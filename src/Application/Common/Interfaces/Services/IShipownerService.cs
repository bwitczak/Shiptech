namespace Shiptech.Application.Common.Interfaces.Services;

public interface IShipownerService
{
    Task<bool> ExistsById(Ulid id);
    Task<bool> ExistsByOrderer(string orderer);
}
