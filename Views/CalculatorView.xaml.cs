using Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator.Views
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : UserControl
    {
        private readonly CalculatorViewModel viewModel;
        public CalculatorView()
        {
            viewModel = new CalculatorViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }

        private void FilterAllowedChars(object sender, TextCompositionEventArgs e)
        {
            string allowedCharacters = "0123456789()/-*+.";

            if (e.Text.Any(c => !allowedCharacters.Contains(c)))
            {
                e.Handled = true;
            }
        }

    }
}
