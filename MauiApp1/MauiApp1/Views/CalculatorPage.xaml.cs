using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class CalculatorPage : ContentPage
{
    public CalculatorPage(CalculatorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}