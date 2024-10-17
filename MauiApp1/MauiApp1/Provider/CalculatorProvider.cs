using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Provider
{
    public class CalculatorProvider : ObservableObject
    {
        public ObservableCollection<CalculatorClass> calculatorClasses;

        public CalculatorProvider() 
        {
            calculatorClasses = new();
        }

        public void addCalculator()
        {
            calculatorClasses.Add(new CalculatorClass());
        }

        public void removeCalculator(CalculatorClass cal)
        {
            calculatorClasses.Remove(cal);
        }
    }
}
