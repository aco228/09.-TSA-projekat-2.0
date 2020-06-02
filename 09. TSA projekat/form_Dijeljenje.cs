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
    public partial class form_Dijeljenje : Form
    {
        public form_Dijeljenje(Engine e)
        {
            InitializeComponent();
            engine = e;
        }

        Engine engine;

        private void form_Dijeljenje_Load_1(object sender, EventArgs e)
        {
            m2.Text = engine.m[2].ToString();
            m1.Text = engine.m[1].ToString();
            m0.Text = engine.m[0].ToString();

            n2.Text = engine.n[2].ToString();
            n1.Text = engine.n[1].ToString();
            n0.Text = engine.n[0].ToString();

        }
    }
}
