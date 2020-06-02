using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _09.TSA_projekat
{
    public partial class form_PointWise : Form
    {
        public form_PointWise(Engine e)
        {
            InitializeComponent();
            engine = e;
        }
        Engine engine;
        private void form_PointWise_Load(object sender, EventArgs e)
        {
            p0.Text = engine.R[0].ToString();
            p1.Text = engine.R[1].ToString();
            p2.Text = engine.R[2].ToString();
            p3.Text = engine.R[3].ToString();
            p4.Text = engine.R[4].ToString();
        }
    }
}
