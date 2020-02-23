using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Windows.Forms;
using System.Drawing;

namespace Simulator
{
    public partial class simulator : Form
    {
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
            label_random();
        }

        private void simulator_Load(object sender, EventArgs e)
        {
            label1.BackColor= Color.Transparent;
            label2.BackColor= Color.Transparent;
            label3.BackColor= Color.Transparent;
            label4.BackColor= Color.Transparent;
        }
    }
}
