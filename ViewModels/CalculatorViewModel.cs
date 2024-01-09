using Calculator.Commands;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.ViewModels
{
    internal class CalculatorViewModel : ViewModelBase
    {
        private CalculatorModel model;
        private string displayText = string.Empty;

        public CalculatorViewModel()
        {
            model = new CalculatorModel();
            InputButtonCommand = new SimpleCommand(param => InputButton(param as string));
            FunctionButtonCommand = new SimpleCommand(param => FunctionButton(param as string));
            EqualsButtonCommand = new SimpleCommand(param => EqualsButton());
        }

        public ICommand InputButtonCommand { get; set; }
        public ICommand EqualsButtonCommand { get; set; }
        public ICommand FunctionButtonCommand { get; set; }

        public string DisplayText
        {
            get => displayText;
            set
            {
                displayText = value;
                OnPropertyChanged();
            }
        }

        private void FunctionButton(string function)
        {
            switch (function)
            {
                case "c":
                    DisplayText = string.Empty;
                    break;
                case "back":
                    DisplayText = !string.IsNullOrEmpty(displayText) ? DisplayText.Substring(0, DisplayText.Length - 1) : "";
                    break;
                default:
                    break;
            }
        }

        private void InputButton(string input)
        {
            DisplayText += input;
        }

        private void EqualsButton()
        {
            double? result = model.CalculateExpression(DisplayText);
            if (result != null)
                DisplayText = result.ToString();
            else
                DisplayText = string.Empty;
        }
    }
}
