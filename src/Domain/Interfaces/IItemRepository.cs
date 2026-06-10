using Domain.Entities;

namespace Domain.Interfaces;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Item item, CancellationToken cancellationToken = default);
    Task UpdateAsync(Item item, CancellationToken cancellationToken = default);
    Task DeleteAsync(Item item, CancellationToken cancellationToken = default);
}
