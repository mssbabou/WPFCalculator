using Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Commands
{
    public class CalculateExpressionCommand : CommandBase
    {
        private readonly CalculatorViewModel calculatorViewModel;

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
