namespace AlmacenesPorAhiMaui.Models;

public class Cliente
{
    public string Rut { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Preferencia { get; set; } = string.Empty;
    public string Resumen => $"{Rut} · {Email}";
}
