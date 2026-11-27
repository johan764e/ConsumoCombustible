namespace ConsumoCombustible.Models;

public class Consumo
{
    public double Km { get; set; }
    public double Litros { get; set; }

    public double Rendimiento() => Km / Litros;
}