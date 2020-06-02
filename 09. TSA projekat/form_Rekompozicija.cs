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
    public partial class form_Rekompozicija : Form
    {
        public form_Rekompozicija(Engine e)
        {
            InitializeComponent();
            engine = e;
        }
        Engine engine;
        private void form_Rekompozicija_Load(object sender, EventArgs e)
        {
            rezultat.Text = engine.dodajRazmak(engine.FINALNI_REZULTAT);
            uporedjivanje = engine.dodajRazmak(engine.r[0].ToString()).Length;
            dodaj(8, engine.dodajRazmak(engine.r[0].ToString()));
            dodaj(6, engine.dodajRazmak(engine.r[1].ToString()));
            dodaj(4, engine.dodajRazmak(engine.r[2].ToString()));
            dodaj(2, engine.dodajRazmak(engine.r[3].ToString()));
            dodaj(0, engine.dodajRazmak(engine.r[4].ToString()));

        }
        int uporedjivanje = 0;
        private void dodaj(int br, string unos){
            // dodavanje razmaka
            string back = "\r\n";
            for (int i = 0; i < (engine.velicina1 + 3) * br; i++) back += ' ';
            if(unos.Length!=uporedjivanje){
                //MessageBox.Show(uporedjivanje + " " + unos.Length);
                for (int j = 0; j <= uporedjivanje - unos.Length; j++) { unos = "_" + unos; if(br==0) rezultat.Text = '_' + rezultat.Text; }
            }
            back += unos;
            tab.Text += back;
        }
    }
}
