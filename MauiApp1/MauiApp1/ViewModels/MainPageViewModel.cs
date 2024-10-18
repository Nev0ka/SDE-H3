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
        private readonly CalculatorList _calculatorList;

        [ObservableProperty]
        private ObservableCollection<CalculatorClass> calculators;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private CalculatorClass selectedCalculator;

        private Dictionary<int, CalculatorViewModel> calculatorViewModels;

        public MainPageViewModel(CalculatorList calculatorList, IServiceProvider serviceProvider)
        {
            _calculatorList = calculatorList;
            calculators = new ObservableCollection<CalculatorClass>(_calculatorList.Calculators);
            calculatorViewModels = new Dictionary<int, CalculatorViewModel>();
        }

        [RelayCommand]
        private async Task OpenCalculator(CalculatorClass calculator)
        {
            await Shell.Current.GoToAsync($"{nameof(CalculatorPage)}?Id={calculator.Id}");
        }

        [RelayCommand]
        private void AddCalculator()
        {
            var newCalculator = new CalculatorClass
            {
                Id = _calculatorList.Calculators.Count > 0 ? _calculatorList.Calculators.Max(c => c.Id) + 1 : 1,
                Name = $"Calculator {_calculatorList.Calculators.Count + 1}",
                Result = 0
            };
            _calculatorList.Calculators.Add(newCalculator);
            Calculators.Add(newCalculator);
        }

        [RelayCommand]
        private void RemoveCalculator(CalculatorClass cal)
        {
            _calculatorList.Calculators.Remove(cal);
            Calculators.Remove(cal);
            calculatorViewModels.Remove(cal.Id);
        }
    }
}