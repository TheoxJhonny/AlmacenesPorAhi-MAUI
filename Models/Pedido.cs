namespace AlmacenesPorAhiMaui.Models;

public class Pedido
{
    public string Numero { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Resumen => $"{Cliente} · {Fecha:dd/MM/yyyy}";
}
