namespace AlmacenesPorAhiMaui.Models;

public class Venta
{
    public string Folio { get; set; } = string.Empty;
    public string Producto { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal Total { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Resumen => $"{Cliente} · {Cantidad} unidad(es) · {Fecha:dd/MM/yyyy HH:mm}";
    public string TotalTexto => $"${Total:N0}";
}
