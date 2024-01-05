using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    internal class CalculatorModel
    {
        public double? CalculateExpression(string expression)
        {
            try
            {
                NCalc.Expression e = new NCalc.Expression(expression);
                double result = Convert.ToDouble(e.Evaluate());
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }
    }
}
