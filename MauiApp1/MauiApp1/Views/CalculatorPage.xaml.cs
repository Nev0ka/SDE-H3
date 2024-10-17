using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class CalculatorPage : ContentPage
{
    public CalculatorPage(CalculatorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}