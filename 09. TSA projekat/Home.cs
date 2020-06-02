using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace _09.TSA_projekat
{
    public partial class Home : Form
    {
        public Home(){
            InitializeComponent();
            uvodnaCrtanja();
        }
        private void uvodnaCrtanja(){
            Bitmap btm_gornja = global::_09.TSA_projekat.Resursi.gornja;
            Graphics GG = Graphics.FromImage(btm_gornja);

            // CRTANJE ZA GORNJI HEADER
            GG.DrawImage(global::_09.TSA_projekat.Resursi.logo, 56, 46);
            upisivanjeTeksta(15, "Завршни пројекат из ‘Теорије сложености алгоритама’", 119,45, Color.FromArgb(193,193,193), GG);
            upisivanjeTeksta(22, "‘Toom–Cook multiplication’ алгоритам", 115,63, Color.FromArgb(193,193,193), GG);
            this.back_gornja.Image = btm_gornja;

            // CRTANJE ZA DOLJNJI HEADER
            Bitmap btm_doljnja = global::_09.TSA_projekat.Resursi.doljnja;
            Graphics GD = Graphics.FromImage(btm_doljnja);
            upisivanjeTeksta(15, "Александар Конатар", 359 + 135, 37 - 7, Color.FromArgb(160, 160, 160), GD);
            upisivanjeTeksta(12, "Д смјер [ 20 / 12 ]", 384 + 135, 57 - 7, Color.FromArgb(160, 160, 160), GD);
            upisivanjeTeksta(15, "Иван Перовић", 78 + 135, 37 - 7, Color.FromArgb(160, 160, 160), GD);
            upisivanjeTeksta(12, "Д смјер [ 05 / 11 ]", 82 + 135, 57 - 7, Color.FromArgb(160, 160, 160), GD);
            //upisivanjeTeksta(15, "Жељко Бујиша", 690, 37, Color.FromArgb(160, 160, 160), GD);
            //upisivanjeTeksta(12, "Д смјер [ 01 / 11 ]", 696, 57, Color.FromArgb(160, 160, 160), GD);
            this.back_doljnja.Image = btm_doljnja;
        }
        private void upisivanjeTeksta(int velicina, string tekst, int x, int y, Color boja, Graphics GD){
            Font font = new System.Drawing.Font("Calibri", velicina, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            GD.DrawString(tekst, font, new SolidBrush(Color.Black), x+1,y+1);
            GD.DrawString(tekst, font, new SolidBrush(boja), x,y);
        }
        private void Home_Load(object sender, EventArgs e){}
        private void btnPrimjer_Click(object sender, EventArgs e){
            unos1.Text = "12 3456 7890 1234 5678 9012";
            unos2.Text = "9 8765 4321 9876 5432 1098";
        }
        private void btnPonisti_Click(object sender, EventArgs e){
            unos1.Text = "";
            unos2.Text = "";
        }

        // Potvrda
        string broj1 = "";
        string broj2 = "";
        Engine engine;

        private void btn_potvrdi_Click(object sender, EventArgs e){
            broj1 = unos1.Text; broj2 = unos2.Text;
            if(provjeraUnosa()){
                engine = new Engine(broj1, broj2);
                engine.dijeljenje();
                engine.evaluacija();
                engine.multiplikacija();
                engine.interopolacija();
                engine.rekompozicija();

                otvaranjePanela();
            } else { broj1 = ""; broj2 = ""; }
        }
        private bool provjeraUnosa(){
            // Provjera praznog unosa
            if(broj1=="") { otvoriKonzolu("Нисте унијели први број!"); return false; }
            if(broj2=="") { otvoriKonzolu("Нисте унијели други број!"); return false; }
            // Provjera znakova
            broj1 = broj1.Replace(" ",String.Empty); broj2 = broj2.Replace(" ",String.Empty);
            for(int i = 0; i < broj1.Length; i++) if(!Char.IsDigit(broj1[i])) {otvoriKonzolu("У првом броју сте унијели недозвољени знак! |Дозвољени су бројеви и размаци!"); return false;  }
            for(int i = 0; i < broj2.Length; i++) if(!Char.IsDigit(broj2[i])) { otvoriKonzolu("У другом броју сте унијели недозвољени знак! |Дозвољени су бројеви и размаци!"); return false;  }
            // Provjera ogranicenja unosa
            if (broj1.Length < 6) { brojManjiOd6(1); return false; }
            if (broj2.Length < 6) { brojManjiOd6(2); return false; }
            return true;
        }

        /*
            PANEL
         */
        Bitmap panel_background;
        private void otvaranjePanela(){
            // KONZOLA
            konzolaBB = new Bitmap(this.Width, this.Height);
            Graphics GB = Graphics.FromImage(konzolaBB);

            // Crtanje sjenke
            GB.CopyFromScreen(this.Location.X + 8, this.Location.Y + 30, 0, 0, konzolaBB.Size);
            GB.DrawImage(new Bitmap(global::_09.TSA_projekat.Resursi.sjenka), -11, -32);

            // Otvaranje konzole
            konzola.Width = this.Width;
            konzola.Height = this.Height;
            konzola.Image = konzolaBB;
            konzola.Visible = true;

            // OTVARANJE PANELA
            panel_prviBr.Text = engine.dodajRazmak(engine.broj1);
            panel_drugiBr.Text = engine.dodajRazmak(engine.broj2);
            panel_rezultat.Text = engine.dodajRazmak(engine.FINALNI_REZULTAT);

            // Crtanje backgrounda panela
            panel_background = new Bitmap(panel.Width, panel.Height);
            Graphics GP = Graphics.FromImage(panel_background);
            GP.CopyFromScreen(this.Location.X + 8 + 29, this.Location.Y + 30 + 22, 0, 0, panel_background.Size);
            GP.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), 0, 0, panel.Width, panel.Height);
            GP.DrawImage(new Bitmap(global::_09.TSA_projekat.Resursi.panel_sjenka), 0, 0);
            panel.BackgroundImage = panel_background;

            panel.Location = new Point(29, 22);
            panel.Visible = true;
            panel.BringToFront();
        }
        private void panel_dijeljenje_Click(object sender, EventArgs e){ form_Dijeljenje F = new form_Dijeljenje(engine); F.Show(); }
        private void panel_evaluacija_Click(object sender, EventArgs e){ form_Evaluacija F = new form_Evaluacija(engine); F.Show(); }
        private void panel_pointwise_Click(object sender, EventArgs e) { form_PointWise F = new form_PointWise(engine);   F.Show(); }
        private void panel_interopolacija_Click(object sender, EventArgs e){ form_Interopolation F = new form_Interopolation(engine); F.Show(); }
        private void panel_rekompozicija_Click(object sender, EventArgs e){  form_Rekompozicija F = new form_Rekompozicija(engine);   F.Show(); }
        private void panel_zatvori_Click(object sender, EventArgs e) { panel.Visible = false; zatvoriKonzolu(); panel_background.Dispose(); }

        /*
            PRIKAZIVANJE POPTPUNOG BROJA 
        */
        private void panel_prviBr_Click(object sender, EventArgs e){ MessageBox.Show(panel_prviBr.Text.Replace(" ", String.Empty), "Први број!"); }
        private void panel_drugiBr_Click(object sender, EventArgs e) { MessageBox.Show(panel_drugiBr.Text.Replace(" ", String.Empty), "Други број!"); }
        private void panel_rezultat_Click(object sender, EventArgs e) { MessageBox.Show(panel_rezultat.Text.Replace(" ", String.Empty), "Резултат!"); }


        /* KONZOLA */
        private void brojManjiOd6(int br){
            BigInteger rezultat = BigInteger.Parse(broj1) * BigInteger.Parse(broj2);
            string broj = "првог"; if(br==2) broj = "другог";
            otvoriKonzolu("Грешка код " + broj + " броја. |Из непровјерених извора број мора имати 6 цифара!||Резултат множења без Том-Куковог алгоритма је:|"+rezultat.ToString());
        }

        Bitmap konzolaBB;
        private void otvoriKonzolu(string tekst){
            // Crtanje backgrounda
            konzolaBB = new Bitmap(this.Width, this.Height);
            Graphics G = Graphics.FromImage(konzolaBB);
            G.CopyFromScreen(this.Location.X + 8, this.Location.Y + 30, 0, 0, konzolaBB.Size);

            // Crtanje pozadine
            G.FillRectangle(new SolidBrush(Color.FromArgb(210,0,0,0)), new Rectangle(0,0,this.Width, this.Height));

            // Crtanje teksta
            string[] nizovi = tekst.Split('|');
            int y = (int)Math.Floor((double)((this.Height+15)/2)-(double)(nizovi.Length*25/2)-25);
            for(int i = 0; i < nizovi.Length; i++){
                int x = 20; // (int)Math.Floor((double)((this.Width) / 2) - (double)((nizovi[i].Length * 9) / 2));
                y += 25;
                upisivanjeTeksta(15, nizovi[i] /*+ ": " + x + ", " + y*/, x, y, Color.FromArgb(255, 255, 255), G);
            }

            // Otvaranje konzole
            upisivanjeTeksta(13, "Кликните на екран да изађете!", 15, this.Height-70, Color.FromArgb(173,178,193), G);
            konzola.Width = this.Width; 
            konzola.Height = this.Height;
            konzola.Image = konzolaBB;
            konzola.Visible = true;
        }
        private void konzola_Click(object sender, EventArgs e) { zatvoriKonzolu(); }
        private void zatvoriKonzolu() { konzola.Visible = false; konzolaBB.Dispose(); }
    }
}
