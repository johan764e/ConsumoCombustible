using ConsumoCombustible.ViewModels;

namespace ConsumoCombustible.Views;

public partial class ConsumoPage : ContentPage
{
    public ConsumoPage()
    {
        InitializeComponent();
        BindingContext = new ConsumoViewModel();
    }
}
