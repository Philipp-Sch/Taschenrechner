using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class MainForm : Form
    {
        private int operation, firstSign, secondSign;
        private string resultString;
        private double[] result;

        public MainForm()
        {
            InitializeComponent();
            //1=+, 2=-, 3=*, 4=/
            operation = 0;
            firstSign = 0;
            secondSign = 0;
            //
            resultString = "";
            result = new double[3];
        }

        private void offButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Number Buttons
        private void zeroButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "0";
        }

        private void oneButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "1";
        }

        private void twoButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "2";
        }

        private void threeButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "3";
        }

        private void fourButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "4";
        }

        private void fiveButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "5";
        }

        private void sixButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "6";
        }

        private void sevenButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "7";
        }

        private void eightButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "8";
        }

        private void nineButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text += "9";
        }
        #endregion

        private void addButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(calculationTextBox.Text) && firstSign == 0)
            {
                firstSign = 1;
                calculationTextBox.Text += "+";
            }
            else if (operation == 0)
            {
                operation = 1;
                calculationTextBox.Text += "+";
            }
            else if (secondSign == 0 && "+-*/".Contains(Convert.ToString(calculationTextBox.Text[calculationTextBox.Text.Length - 1])))
            {
                secondSign = 1;
                calculationTextBox.Text += "+";
            }
        }

        private void subtractButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(calculationTextBox.Text) && firstSign == 0)
            {
                firstSign = 2;
                calculationTextBox.Text += "-";
            }
            else if (operation == 0)
            {
                operation = 2;
                calculationTextBox.Text += "-";
            }
            else if (secondSign == 0 && "+-*/".Contains(Convert.ToString(calculationTextBox.Text[calculationTextBox.Text.Length - 1])))
            {
                secondSign = 2;
                calculationTextBox.Text += "-";
            }
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            if (calculationTextBox.Text.Length > 0 && "0123456789".Contains(Convert.ToString(calculationTextBox.Text[calculationTextBox.Text.Length - 1])))
            {
                calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
            }
            else if (secondSign != 0)
            {
                switch (calculationTextBox.Text[calculationTextBox.Text.Length - 1])
                {
                    case '+':
                        secondSign = 0;
                        calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
                        break;
                    case '-':
                        secondSign = 0;
                        calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
                        break;
                }
            }
            else if (operation != 0)
            {
                switch (calculationTextBox.Text[calculationTextBox.Text.Length - 1])
                {
                    case '+':
                        operation = 0;
                        calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
                        break;
                    case '-':
                        operation = 0;
                        calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
                        break;
                    case '*':
                        operation = 0;
                        calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
                        break;
                    case '/':
                        operation = 0;
                        calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
                        break;
                }
            }
            else if (firstSign != 0)
            {
                switch (calculationTextBox.Text[calculationTextBox.Text.Length - 1])
                {
                    case '+':
                        firstSign = 0;
                        calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
                        break;
                    case '-':
                        firstSign = 0;
                        calculationTextBox.Text = calculationTextBox.Text.Remove(calculationTextBox.Text.Length - 1, 1);
                        break;
                }
            }
        }

        private void allClearButtonClick(object sender, EventArgs e)
        {
            calculationTextBox.Text = "";
            firstSign = 0;
            operation = 0;
            secondSign = 0;
        }

        private void equalsButtonClick(object sender, EventArgs e)
        {
            try
            {
                resultString = calculationTextBox.Text;
                switch (operation)
                {
                    case 0:
                        break;
                    case 1:
                        result[0] = Convert.ToDouble(resultString.Substring(0, resultString.IndexOf('+')));
                        break;
                    case 2:
                        result[0] = Convert.ToDouble(resultString.Substring(0, resultString.IndexOf('-')));
                        break;
                    case 3:
                        result[0] = Convert.ToDouble(resultString.Substring(0, resultString.IndexOf('*')));
                        break;
                    case 4:
                        result[0] = Convert.ToDouble(resultString.Substring(0, resultString.IndexOf('/')));
                        break;
                }
                //
                if (secondSign == 1)
                {
                    result[1] = Convert.ToDouble(resultString.Substring(resultString.LastIndexOf('+'), resultString.Length - resultString.LastIndexOf('+')));
                }
                else if (secondSign == 2)
                {
                    result[1] = Convert.ToDouble(resultString.Substring(resultString.LastIndexOf('-'), resultString.Length - resultString.LastIndexOf('-')));
                }
                else if (operation == 1)
                {
                    result[1] = Convert.ToDouble(resultString.Substring(resultString.LastIndexOf('+'), resultString.Length - resultString.LastIndexOf('+')));
                }
                else if (operation == 2)
                {
                    result[1] = Convert.ToDouble(resultString.Substring(resultString.LastIndexOf('-'), resultString.Length - resultString.LastIndexOf('-')));
                }
                else if (operation == 3)
                {
                    result[1] = Convert.ToDouble(resultString.Substring(resultString.LastIndexOf('*') + 1, resultString.Length - resultString.LastIndexOf('*') - 1));
                }
                else if (operation == 4)
                {
                    result[1] = Convert.ToDouble(resultString.Substring(resultString.LastIndexOf('/') + 1, resultString.Length - resultString.LastIndexOf('/') - 1));
                }
                //
                switch (operation)
                {
                    case 0:
                        break;
                    case 1:
                        result[2] = result[0] + result[1];
                        break;
                    case 2:
                        result[2] = result[0] - result[1];
                        break;
                    case 3:
                        result[2] = result[0] * result[1];
                        break;
                    case 4:
                        result[2] = result[0] / result[1];
                        break;
                }
                //
                resultsListBox.Items.Add(calculationTextBox.Text + "=" + Convert.ToString(result[2]));
                calculationTextBox.Text = "";
                firstSign = 0;
                operation = 0;
                secondSign = 0;
            }
            catch (Exception)
            {
                resultsListBox.Items.Add(calculationTextBox.Text + "=Error!");
                calculationTextBox.Text = "";
                firstSign = 0;
                operation = 0;
                secondSign = 0;
            }
        }

        private void multiplyButtonClick(object sender, EventArgs e)
        {
            if (operation == 0)
            {
                operation = 3;
                calculationTextBox.Text += "*";
            }
        }

        private void divideButtonClick(object sender, EventArgs e)
            {
            if (operation == 0)
            {
                operation = 4;
                calculationTextBox.Text += "/";
            }
        }
    }
}