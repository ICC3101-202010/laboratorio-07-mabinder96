using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_7
{
    public partial class Calculator : Form
    {
        decimal result = 0;
        string br="0";
        string operation="";
        bool operperf = false;
        
        

        public Calculator()
        {
            InitializeComponent();
        }

     

        private void N_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || operperf==true)
            {
                textBox1.Clear();

            }
            operperf = false;
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void dell_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text =textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void Operation(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            operation = button.Text;
            try
            {
                result = decimal.Parse(textBox1.Text);
                operationlebel.Text = result + " " + operation + " ";
                operperf = true;
            }
            catch (SystemException)
            {
                textBox1.Text = "SyntaxERROR";
            }
            
            
            
        }

        private void AC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            br = "0";
            operationlebel.Text = "";
            result = 0;
        }

        private void igual_Click(object sender, EventArgs e)
        {
            operationlebel.Text += textBox1.Text;
            switch (operation)
            {
                case "+":
                    try
                    {
                        textBox1.Text = (result + decimal.Parse(textBox1.Text)).ToString();
                        br = textBox1.Text;
                        operperf = true;



                    }
                    catch (SystemException)
                    {
                        textBox1.Text = "SyntaxERROR";
                        operperf = true;
                    }

                    break;
                case "-":
                    try
                    {
                        textBox1.Text = (result - decimal.Parse(textBox1.Text)).ToString();
                        br = textBox1.Text;
                        operperf = true;

                    }
                    catch (SystemException)
                    {
                        textBox1.Text = "SyntaxERROR";
                        operperf = true;
                    }
                    break;
                case "÷":
                    try
                    {
                        textBox1.Text = (result / decimal.Parse(textBox1.Text)).ToString();
                        br = textBox1.Text;
                        operperf = true;

                    }
                    catch (DivideByZeroException)
                    {
                        textBox1.Text = "MathERROR";
                        operperf = true;
                    }
                    catch (SystemException)
                    {
                        textBox1.Text = "SyntaxERROR";
                        operperf = true;
                    }

                    break;
                case "x":
                    try
                    {
                        textBox1.Text = (result * decimal.Parse(textBox1.Text)).ToString();
                        br = textBox1.Text;
                        operperf = true;


                    }
                    catch (SystemException)
                    {
                        textBox1.Text = "SyntaxERROR";
                        operperf = true;

                    }
                    break;
                default:
                    try
                    {
                        textBox1.Text = (decimal.Parse(textBox1.Text)).ToString();
                        br = textBox1.Text;
                        operperf = true;

                    }
                    catch (SystemException)
                    {
                        textBox1.Text = "SyntaxERROR";
                        operperf = true;
                    }

                    break;
            }
        }
        

        private void ans_Click(object sender, EventArgs e)
        {
            textBox1.Text =br;
        }

        private void history_Click(object sender, EventArgs e)
        {
            historialpanel.Visible = true;
        }
    }
}
