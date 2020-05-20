using System;
using System.Windows.Forms;

namespace Laboratorio_7
{

    [Serializable]
    public partial class Calculator : Form
    {

        decimal result = 0;
        string br="0";
        string operation="";
        string oper2 = "";
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

        private void Dell_Click(object sender, EventArgs e)
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
                oper2 = result + " " + operation + " ";
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
            textBoxhistorial.ResetText();

        }

        private void Igual_Click(object sender, EventArgs e)
        {
            operationlebel.Text += textBox1.Text;
            oper2 += textBox1.Text;
            switch (operation)
            {
                case "+":
                    try
                    {
                        textBox1.Text = (result + decimal.Parse(textBox1.Text)).ToString();
                        br = textBox1.Text;
                        oper2 += " = " + textBox1.Text;

                        textBoxhistorial.AppendText(oper2 + Environment.NewLine);
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
                        oper2 += " = " + textBox1.Text;
                        textBoxhistorial.AppendText(oper2 + Environment.NewLine);
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
                        oper2 += " = " + textBox1.Text;
                        textBoxhistorial.AppendText(oper2+ Environment.NewLine);
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
                        oper2 += " = " + textBox1.Text;
                        textBoxhistorial.AppendText(oper2 + Environment.NewLine);
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
        

        private void Ans_Click(object sender, EventArgs e)
        {
            textBox1.Text =br;
        }

        private void History_Click(object sender, EventArgs e)
        {


            if (historialpanel.Visible == false)
            {
                historialpanel.Visible = true;
                textBoxhistorial.Visible = true;
                deletehistorial.Visible = true;
                historialtitle.Visible = true;
            }
            else
            {
                historialpanel.Visible = false;
                textBoxhistorial.Visible = false;
                deletehistorial.Visible = false;
                historialtitle.Visible = false;
            }

        }

        private void Deletehistorial_Click(object sender, EventArgs e)
        {
            textBoxhistorial.ResetText();
        }
    }
}
