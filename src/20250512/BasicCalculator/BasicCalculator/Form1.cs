using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        private string _firstNumber;
        private string _lastOperator;
        private bool _operatorIsClicked;

        public Form1()
        {
            InitializeComponent();

            _firstNumber = string.Empty;
            _lastOperator = string.Empty;
        }

  
        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_output.Text = "0";
        }

        private void btt_num_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button == null)
            {
                return;
            }

            //eg: "0" => "07"
            if(lbl_output.Text == "0")
            {
                lbl_output.Text = string.Empty;
            }

            if (_operatorIsClicked)
            {
                lbl_output.Text = string.Empty;
                _operatorIsClicked = false;
            }

            //limit count of digits
            if (lbl_output.Text.Length < 9)
            {
                lbl_output.Text += button.Text;
            }
        }

        private void btt_operator_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            _firstNumber = lbl_output.Text;
            _lastOperator = button.Text;

            _operatorIsClicked = true;
        }

        private void btt_equals_Click(object sender, EventArgs e)
        {
            int result = 0;

            //_firstNumber  operator  lbl_output.Text
            int firstNumber = int.Parse(_firstNumber);
            int secondNumber = int.Parse(lbl_output.Text);

            switch (_lastOperator)
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

                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }

            lbl_output.Text = result.ToString();
            _lastOperator = string.Empty;
            _operatorIsClicked = true;
        }

        private void btt_clear_Click(object sender, EventArgs e)
        {
            _lastOperator = string.Empty;
            _firstNumber = string.Empty;
            lbl_output.Text = "0";
            _operatorIsClicked = false;
        }
    }
}
