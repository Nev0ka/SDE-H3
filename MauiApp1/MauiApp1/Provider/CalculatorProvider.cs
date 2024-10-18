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
        private int _nextId = 1;

        public CalculatorProvider()
        {
            calculatorClasses = new();
        }

        private (int id, string name) GenerateUniqueCalculatorDetails()
        {
            int id = _nextId++;
            string name = $"Calculator {id}";
            return (id, name);
        }
    }
}
