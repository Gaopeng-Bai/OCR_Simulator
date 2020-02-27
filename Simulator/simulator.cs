using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Windows.Forms;
using System.Drawing;

namespace Simulator
{
    public partial class simulator : Form
    {
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public simulator()
        {
            InitializeComponent();
        }

       
        private void label_random()
        {
            
            float a = Conversion.Int(2 * VBMath.Rnd() + 0);
            if (a == 0)
            {
                label1.Text = Conversions.ToString(Conversion.Int(999 * VBMath.Rnd() + 0)) + "," + Conversions.ToString(Conversion.Int(8 * VBMath.Rnd() + 1));
                label2.Text = Conversions.ToString(Conversion.Int(364 * VBMath.Rnd() + 1)) + "," + Conversions.ToString(Conversion.Int(8 * VBMath.Rnd() + 1));
                label3.Text = Conversions.ToString(Conversion.Int(999 * VBMath.Rnd() + 0)) + "," + Conversions.ToString(Conversion.Int(8 * VBMath.Rnd() + 1));
                label4.Text = Conversions.ToString(Conversion.Int(364 * VBMath.Rnd() + 1)) + "," + Conversions.ToString(Conversion.Int(8 * VBMath.Rnd() + 1));
            }
            else
            {
                label1.Text = Conversions.ToString(Conversion.Int(999 * VBMath.Rnd() + 0));
                label2.Text = Conversions.ToString(Conversion.Int(364 * VBMath.Rnd() + 1));
                label3.Text = Conversions.ToString(Conversion.Int(999 * VBMath.Rnd() + 0));
                label4.Text = Conversions.ToString(Conversion.Int(364 * VBMath.Rnd() + 1));
            }
        }
        private void Single_Click(object sender, EventArgs e)
        {
            myTimer.Stop();
            label_random();
        }

        private void simulator_Load(object sender, EventArgs e)
        {
            label1.BackColor= Color.Transparent;
            label2.BackColor= Color.Transparent;
            label3.BackColor= Color.Transparent;
            label4.BackColor= Color.Transparent;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Timer interval can not be empty", "Warining");
            }
            else
            {
                myTimer.Stop();
                myTimer.Tick += new EventHandler(Callback);
                myTimer.Enabled = true;
                //set timer interrval, ms.
                myTimer.Interval = int.Parse(textBox1.Text)*1000;//1s 
            }
        }

        private void Callback(object sender, EventArgs e)
        {
            label_random();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void simulator_FormClosing(object sender, FormClosingEventArgs e)
        {

            System.Environment.Exit(0);
        }
    }
}
