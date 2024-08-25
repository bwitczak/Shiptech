using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IShipFactory
{
    Ship Create(Ulid id, string code, string orderer);
}
