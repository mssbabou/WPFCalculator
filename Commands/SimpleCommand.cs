using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Commands
{
    public class SimpleCommand : CommandBase
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public SimpleCommand(Action<object> execute) : this(execute, null)
        {
        }

        public SimpleCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
