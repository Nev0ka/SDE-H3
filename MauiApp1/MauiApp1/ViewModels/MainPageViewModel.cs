using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Provider;
using MauiApp1.Classes;

namespace MauiApp1.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly CalculatorProvider _calculatorProvider;

        [ObservableProperty]
        private ObservableCollection<CalculatorClass> calculator;

        public MainPageViewModel(CalculatorProvider calculatorProvider)
        {
            _calculatorProvider = calculatorProvider;
            calculator = _calculatorProvider.calculatorClasses;
        }

        [RelayCommand]
        private async Task OpenCalculator()
        {
            await Shell.Current.GoToAsync(nameof(CalculatorPage));
        }

        [RelayCommand]
        private async Task AddCalculator()
        {
            _calculatorProvider.addCalculator();
        }

        [RelayCommand]
        private async Task RemoveCalculator(CalculatorClass cal)
        {
            _calculatorProvider.removeCalculator(cal);
        }
    }
}