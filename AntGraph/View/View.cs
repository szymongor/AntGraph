using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntGraph.View
{
    public partial class View : UserControl
    {
        Graphics canvas;

        public View()
        {
            InitializeComponent();
            canvas = pictureBox1.CreateGraphics();
        }

    }
}
