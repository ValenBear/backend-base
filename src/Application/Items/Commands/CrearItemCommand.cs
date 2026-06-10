using MediatR;

namespace Application.Items.Commands;

public record CrearItemCommand(string Nombre, decimal Monto) : IRequest<Guid>;
