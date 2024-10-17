using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Classes
{
    public class CalculatorClass
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Result { get; set; }
    }

    public class CalculatorList
    {
        public List<CalculatorClass> Calculators { get; set; }

        public CalculatorList()
        {
            Calculators = new List<CalculatorClass>();
        }
    }
}
