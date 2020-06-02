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
    public partial class form_Interopolation : Form
    {
        public form_Interopolation(Engine e)
        {
            InitializeComponent();
            engine = e;
        }
        Engine engine;
        private void form_Interopolation_Load(object sender, EventArgs e)
        {
            p0.Text = engine.r[0].ToString();
            p1.Text = engine.r[1].ToString();
            p2.Text = engine.r[2].ToString();
            p3.Text = engine.r[3].ToString();
            p4.Text = engine.r[4].ToString();
        }
    }
}
