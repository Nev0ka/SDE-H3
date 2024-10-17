using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public partial class CalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _resultDisplay = string.Empty;

        [ObservableProperty]
        private string _expressionDisplay = string.Empty;

        [ObservableProperty]
        private int _cursorPosition;

        [ObservableProperty]
        private string _niceToast = string.Empty;

        [RelayCommand]
        public void HandleButtonPress(string buttonText)
        {
            var curPos = CursorPosition;

            if (buttonText == "AC")
            {
                ExpressionDisplay = string.Empty;
                ResultDisplay = string.Empty;
                CursorPosition = 0;
                NiceToast = string.Empty;
            }
            else if (buttonText == "+/-")
            {
                ToggleSign();
            }
            else if (int.TryParse(buttonText, out var _) || buttonText == "/" || buttonText == ",")
            {
                if (buttonText == "," && !CanInsertDecimal(ExpressionDisplay))
                {
                    return;
                }

                ExpressionDisplay = InsertCharacterAtPosition(ExpressionDisplay, buttonText[0].ToString(), curPos);
                CursorPosition = curPos + 1;

                TryComputeExpression();
            }
            else if (IsOperator(buttonText))
            {
                if (!IsLastCharacterOperator(ExpressionDisplay))
                {
                    ExpressionDisplay = InsertCharacterAtPosition(ExpressionDisplay, buttonText[0].ToString(), curPos);
                    CursorPosition = curPos + 1;
                }
            }
            else if (buttonText == "=")
            {
                TryComputeExpression();
                if (double.TryParse(ResultDisplay, out var result))
                {
                    if (result == 69 || result == 80085)
                    {
                        NiceToast = "Nice!";
                    }
                }
                ExpressionDisplay = ResultDisplay;
                CursorPosition = ExpressionDisplay.Length;
                ResultDisplay = string.Empty;
            }
            else if (buttonText == "DEL")
            {
                if (!string.IsNullOrEmpty(ExpressionDisplay))
                {
                    ExpressionDisplay = ExpressionDisplay.Remove(ExpressionDisplay.Length - 1);
                    CursorPosition = Math.Max(0, CursorPosition - 1);
                }
            }
            else
            {
                ExpressionDisplay = InsertCharacterAtPosition(ExpressionDisplay, buttonText[0].ToString(), curPos);
                CursorPosition = curPos + 1;
            }
        }

        private bool CanInsertDecimal(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return false;
            }

            char lastChar = expression[expression.Length - 1];
            if (IsOperator(lastChar.ToString()))
            {
                return false;
            }

            var parts = Regex.Split(expression, @"[\+\-\*\/]");
            var lastNumber = parts.Last().Trim();

            return !lastNumber.Contains(",");
        }

        private string InsertCharacterAtPosition(string original, string character, int position)
        {
            return original.Insert(position, character);
        }

        private void TryComputeExpression()
        {
            string expressionForCalculation = ExpressionDisplay.Replace(",", ".");

            if (!double.TryParse(expressionForCalculation, out var _))
            {
                try
                {
                    double result = Convert.ToDouble(new DataTable().Compute(expressionForCalculation, null));
                    ResultDisplay = result.ToString();
                }
                catch
                {
                    ResultDisplay = "Format error";
                }
            }
        }

        private void ToggleSign()
        {
            var trimmedExpression = ExpressionDisplay.Trim();

            if (string.IsNullOrEmpty(trimmedExpression)) return;

            if (trimmedExpression.StartsWith("-"))
            {
                ExpressionDisplay = trimmedExpression.Substring(1);
            }
            else
            {
                ExpressionDisplay = "-" + trimmedExpression;
            }

            CursorPosition = ExpressionDisplay.Length;
        }

        private bool IsOperator(string buttonText)
        {
            return buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/";
        }

        private bool IsLastCharacterOperator(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return false;
            char lastChar = expression[expression.Length - 1];
            return IsOperator(lastChar.ToString());
        }
    }
}
