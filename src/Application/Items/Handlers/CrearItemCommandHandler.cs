using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Items.Commands;

public class CrearItemCommandHandler : IRequestHandler<CrearItemCommand, Guid>
{
    private readonly IItemRepository _itemRepository;

    public CrearItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Guid> Handle(CrearItemCommand request, CancellationToken cancellationToken)
    {
        var item = new Item(request.Nombre, request.Monto);
        
        await _itemRepository.AddAsync(item, cancellationToken);
        
        return item.Id;
    }
}
