namespace Domain.Entities;

public class Item
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public decimal Monto { get; private set; }
    public DateTime FechaCreacion { get; private set; }

    // Constructor vacío requerido por EF Core
    protected Item() { }

    public Item(string nombre, decimal monto)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacío.");
        if (monto <= 0)
            throw new ArgumentException("El monto debe ser mayor a 0.");

        Id = Guid.NewGuid();
        Nombre = nombre;
        Monto = monto;
        FechaCreacion = DateTime.UtcNow;
    }

    public void ActualizarMonto(decimal nuevoMonto)
    {
        if (nuevoMonto <= 0)
            throw new ArgumentException("El monto debe ser mayor a 0.");
        Monto = nuevoMonto;
    }
}
