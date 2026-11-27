using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ConsumoCombustible.Models;

namespace ConsumoCombustible.ViewModels;

public class ConsumoViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string? n = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

    string _km = "", _litros = "", _rend = "", _nivel = "", _msg = "";
    public string Km { get => _km; set { _km = value; OnPropertyChanged(); } }
    public string Litros { get => _litros; set { _litros = value; OnPropertyChanged(); } }
    public string Rendimiento { get => _rend; set { _rend = value; OnPropertyChanged(); } }
    public string Nivel { get => _nivel; set { _nivel = value; OnPropertyChanged(); } }
    public string Mensaje { get => _msg; set { _msg = value; OnPropertyChanged(); } }

    public ICommand CalcularCommand { get; }
    public ConsumoViewModel() => CalcularCommand = new Command(Calcular);

    void Calcular()
    {
        Rendimiento = Nivel = Mensaje = "";

        if (!double.TryParse(Km, out double km) || !double.TryParse(Litros, out double lts))
        {
            Mensaje = "Escribe números válidos.";
            return;
        }
        if (km <= 0 || lts <= 0)
        {
            Mensaje = "Los datos deben ser mayores que cero.";
            return;
        }

        double r = new Consumo { Km = km, Litros = lts }.Rendimiento();
        Rendimiento = "Rendimiento: " + r.ToString("F2") + " km/L";
        Nivel = "Nivel: " + (r < 10 ? "Bajo" : r < 15 ? "Medio" : "Alto");
    }
}