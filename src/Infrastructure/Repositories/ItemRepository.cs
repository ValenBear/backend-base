using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _context;

    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Items.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Items.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Item item, CancellationToken cancellationToken = default)
    {
        await _context.Items.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Item item, CancellationToken cancellationToken = default)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Item item, CancellationToken cancellationToken = default)
    {
        _context.Items.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
