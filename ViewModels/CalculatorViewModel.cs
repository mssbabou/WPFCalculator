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

        public ICommand NumberButtonCommand { get; set; }
        public ICommand OperatorButtonCommand { get; set; }
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

        public CalculatorViewModel()
        {
            model = new CalculatorModel();

            NumberButtonCommand = new SimpleCommand(param => NumberButton(param as string));
            OperatorButtonCommand = new SimpleCommand(param => OperatorButton(param as string));
            FunctionButtonCommand = new SimpleCommand(param => FunctionButton(param as string));
            EqualsButtonCommand = new SimpleCommand(param => EqualsButton());
        }

        private void FunctionButton(string function)
        {
            switch (function)
            {
                case "C":
                    DisplayText = string.Empty;
                    break;
                case "CE":
                    DisplayText = string.Empty;
                    break;
                case "Back":
                    DisplayText = !string.IsNullOrEmpty(displayText) ? DisplayText.Substring(0, DisplayText.Length - 1) : "";
                    break;
                default:
                    break;
            }
        }

        private void NumberButton(string number)
        {
            DisplayText += number;
        }

        private void OperatorButton(string operation)
        {
            DisplayText += operation;
        }

        private void EqualsButton()
        {
            DisplayText = model.CalculateExpression(DisplayText).ToString();
        }
    }
}
