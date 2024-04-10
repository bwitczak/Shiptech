using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Repositories
{
    public interface IAssortmentDictionaryRepository
    {
        Task<AssortmentDictionary> GetAsync(Id id);
        Task CreateAsync(AssortmentDictionary assortment);
        Task UpdateAsync(AssortmentDictionary assortment);
        Task DeleteAsync(AssortmentDictionary assortment);
    }
}