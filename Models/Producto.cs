namespace AlmacenesPorAhiMaui.Models;

public class Producto
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Talla { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Resumen => $"{Codigo} · {Categoria} · {Talla} · {Color}";
    public string PrecioTexto => $"${Precio:N0}";
    public string StockTexto => $"Stock: {Stock}";
}
