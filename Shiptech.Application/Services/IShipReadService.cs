namespace Shiptech.Application.Services;

public interface IShipReadService
{
    Task<bool> ExistsByOrderer(string orderer);
}