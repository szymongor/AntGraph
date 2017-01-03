using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown2.Value = 0.2M;
            numericUpDown3.Value = 400;
            numericUpDown2.Increment = 0.001M;
            numericUpDown3.Increment = 1M;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                view1.startAntSimulation((int)numericUpDown1.Value);
                button1.Text = "Stop";
            }
            else
            {
                view1.stopAntSimulation();
                button1.Text = "Start";
            }
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            view1.setPheromoneDecay((double)numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            view1.setPheromoneIncrement((double)numericUpDown3.Value);
        }
    }
}
