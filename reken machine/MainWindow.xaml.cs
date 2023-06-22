using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Reken_Machine
{
    public partial class MainWindow : Window
    {
        private double firstNumber;
        private string selectedOperator;
        private bool isOperatorClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string digit = button.Content.ToString();

            if (isOperatorClicked)
            {
                ResultTextBox.Text = digit;
                isOperatorClicked = false;
            }
            else
            {
                if (ResultTextBox.Text == "0" && digit != ",")
                {
                    ResultTextBox.Text = digit;
                }
                else
                {
                    ResultTextBox.Text += digit;
                }
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            selectedOperator = button.Content.ToString();

            if (!string.IsNullOrEmpty(ResultTextBox.Text))
            {
                firstNumber = double.Parse(ResultTextBox.Text);
                isOperatorClicked = true;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber = double.Parse(ResultTextBox.Text);
            double result = 0;

            switch (selectedOperator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "x":
                    result = firstNumber * secondNumber;
                    break;
                case "÷":
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        MessageBox.Show("Error: Division by zero is not allowed.");
                    }
                    break;
            }

            ResultTextBox.Text = result.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "0";
            firstNumber = 0;
            isOperatorClicked = false;
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ResultTextBox.Text.Contains(","))
            {
                ResultTextBox.Text += ",";
            }
        }
    }
}