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
            numericUpDown2.Increment = 0.001M;
            numericUpDown3.Increment = 0.01M;
            numericUpDown2.Value = 0.750M;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view1.startAntSimulation((int)numericUpDown1.Value);
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
