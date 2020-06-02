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
    public partial class form_Evaluacija : Form
    {
        public form_Evaluacija(Engine e)
        {
            InitializeComponent();
            engine = e;
        }
        Engine engine;
        private void form_Evaluacija_Load(object sender, EventArgs e)
        {
            p0.Text = engine.p[0].ToString();
            p1.Text = engine.p[1].ToString();
            p2.Text = engine.p[2].ToString();
            p3.Text = engine.p[3].ToString();
            p4.Text = engine.p[4].ToString();

            q0.Text = engine.q[0].ToString();
            q1.Text = engine.q[1].ToString();
            q2.Text = engine.q[2].ToString();
            q3.Text = engine.q[3].ToString();
            q4.Text = engine.q[4].ToString();
        }
    }
}
