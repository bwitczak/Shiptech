namespace Shiptech.Application.Services;

public interface IShipReadService
{
    Task<bool> ExistsById(Guid id);
    Task<bool> ExistsByOrderer(string orderer);
}