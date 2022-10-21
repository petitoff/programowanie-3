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

namespace zadanie_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _currentNumber, _lastNumber, _result;
        private string _mathOperation;

        public MainWindow()
        {
            InitializeComponent();

            AcButton.Click += ClearResult_Button;
            NegativeButton.Click += NegativeConvert_Button;
            PercentageButton.Click += PercentageCalculate_Button;
            EqualButton.Click += equal_Button;
            AddButton.Click += AddButtonOnClick;
            SubButton.Click += SubButtonOnClick;
            MultButton.Click += MultButtonOnClick;
            DivisionButton.Click += DivisionButtonOnClick;
        }

        private void FunctionButton()
        {
            _lastNumber = double.Parse(ResultLabel.Content.ToString()!);
            LastNumber.Content = $"{ResultLabel.Content} {this._mathOperation}";
            ResultLabel.Content = "0";
        }

        private void AddButtonOnClick(object sender, RoutedEventArgs e)
        {
            this._mathOperation = "+";
            FunctionButton();
        }

        private void SubButtonOnClick(object sender, RoutedEventArgs e)
        {
            this._mathOperation = "-";
            FunctionButton();
        }

        private void MultButtonOnClick(object sender, RoutedEventArgs e)
        {
            this._mathOperation = "*";
            FunctionButton();
        }

        private void DivisionButtonOnClick(object sender, RoutedEventArgs e)
        {
            this._mathOperation = "/";
            FunctionButton();
        }

        private void equal_Button(object sender, RoutedEventArgs e)
        {
            _currentNumber = double.Parse(ResultLabel.Content.ToString()!);
            LastNumber.Content = "";

            switch (this._mathOperation)
            {
                case "+":
                    this._result = _currentNumber + _lastNumber;
                    break;
                case "-":
                    this._result = _lastNumber - _currentNumber;
                    break;
                case "*":
                    this._result = _currentNumber * _lastNumber;
                    break;
                case "/":
                    this._result = _lastNumber / _currentNumber;
                    break;
            }


            this._mathOperation = "";
            ResultLabel.Content = System.Math.Round(this._result, 6);

        }

        private void PercentageCalculate_Button(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(ResultLabel.Content.ToString(), out _lastNumber))
            {
                return;
            }

            _lastNumber /= 100;
            ResultLabel.Content = _lastNumber.ToString();
        }

        private void NegativeConvert_Button(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(ResultLabel.Content.ToString(), out _lastNumber))
            {
                return;
            }

            _lastNumber *= -1;
            ResultLabel.Content = _lastNumber.ToString();
        }

        private void ClearResult_Button(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void NumberEvent_Button(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;

            if (ResultLabel.Content.ToString()!.Length > 8)
            {
                return;
            }

            if (this._result != 0)
            {
                ResultLabel.Content = 0;
                this._result = 0;
            }

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = content as string;
            }
            else
            {
                ResultLabel.Content += content as string;

            }
        }
    }
}
