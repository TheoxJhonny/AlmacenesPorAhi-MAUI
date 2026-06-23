namespace AlmacenesPorAhiMaui.Models;

public class Devolucion
{
    public string Codigo { get; set; } = string.Empty;
    public string Producto { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public string TipoProceso { get; set; } = string.Empty;
    public string Motivo { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Resumen => $"{Cliente} · {TipoProceso} · {Cantidad} unidad(es)";
}
