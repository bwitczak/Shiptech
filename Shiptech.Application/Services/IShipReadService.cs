namespace Shiptech.Application.Services;

public interface IShipReadService
{
    Task<bool> ExistsById(Ulid id);
    Task<bool> ExistsByOrderer(string orderer);
}