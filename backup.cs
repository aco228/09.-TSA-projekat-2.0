using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;


namespace _09.TSA_projekat
{
    public class Engine
    {
        public string broj1 = "";
        public string broj2 = "";

        public Engine(string a, string b){
            broj1 = a; broj2 = b;
        }

        public string debug = "";

#region DIJELJENJE
        public BigInteger[] m = { 0, 0, 0 };
        public BigInteger[] n = { 0, 0, 0 };
        public int velicina = 0;
        public void dijeljenje(){
            dijeli_broj(broj1, m);
            dijeli_broj(broj2, n);
        }
        private void dijeli_broj(string br, BigInteger[] cast){
            velicina = Convert.ToInt32(Math.Ceiling((double)broj1.Length / 3));
            string dio_broja = "";
            int a = br.Length - 1 - velicina; int b = br.Length - 1;
            
            dio_broja = br.Substring(br.Length-velicina, velicina);
            cast[0] = BigInteger.Parse(dio_broja);

            dio_broja = br.Substring(br.Length - velicina - velicina, velicina);
            cast[1] = BigInteger.Parse(dio_broja);

            // Prvi komad broja
            dio_broja = br.Substring(0, br.Length-(velicina*2));
            cast[2] = BigInteger.Parse(dio_broja);

            debug = cast[0]+"\r\n"+cast[1] + "\r\n" + cast[2];
        }
#endregion

#region EVALUACIJA
        public BigInteger[] p = { 0,0,0,0,0 }; // 0 | 1 | -1 | -2 | x
        public BigInteger[] q = { 0,0,0,0,0 }; // 0 | 1 | -1 | -2 | x
        public void evaluacija(){
            // pq[0]
            p[0] = m[0]; q[0] = n[0];

            // pq[1]
            p[1] = m[0] + m[1] + m[2];
            q[1] = n[0] + n[1] + n[2];

            // pq[-1]
            p[2] = m[0] - m[1] + m[2];
            q[2] = n[0] - n[1] + n[2];

            // pq[-2]
            p[3] = m[0] - (2 * m[1]) + (4 * m[2]);
            q[3] = n[0] - (2 * n[1]) + (4 * n[2]);

            // pq[beskonacno]
            p[4] = m[2]; q[4] = n[2];

            debug= p[0]+"\r\n"+p[1] + "\r\n" + p[2] + "\r\n" + p[3] + "\r\n" + p[4];
        }
#endregion

#region POINTWISE_MULTIPLICATION
        public BigInteger[] R = { 0,0,0,0,0 }; // 0 | 1 | -1 | -2 | x
        public void multiplikacija(){
            // R[0]
            R[0] = p[0]*q[0];

            // R[1]
            R[1] = p[1]*q[1];
            
            // R[-1]
            R[2] = p[2] * q[2];

            // R[-2]
            R[3] = p[3] * q[3];

            // R[beskonacno]
            R[4] = p[4] * q[4];

            debug= R[0]+"\r\n"+R[1] + "\r\n" + R[2] + "\r\n" + R[3] + "\r\n" + R[4];
        }
#endregion

#region INTEROPOLACIJA
        public BigInteger[] r = { 0,0,0,0,0 }; // 0 | 1 | -1 | -2 | x
        public void interopolacija(){
            r[0] = R[0];
            r[4] = R[4];
            r[3] = (R[3] - R[1]) / 3;
            r[1] = (R[1] - R[2]) / 2;
            r[2] = R[2] - R[0];

            r[3] = ((r[2] - r[3]) / 2) + 2 * R[4];
            r[2] = r[2] + r[1] - r[4];
            r[1] = r[1] - r[3];

            debug= r[0]+"\r\n"+r[1] + "\r\n" + r[2] + "\r\n" + r[3] + "\r\n" + r[4];
        }
#endregion

#region REKOMPOZICIJA
        public string FINALNI_REZULTAT = "";
        public void rekompozicija(){            
            cijepanjeRezultata(r[0].ToString());
            cijepanjeRezultata(r[1].ToString());
            cijepanjeRezultata(r[2].ToString());
            cijepanjeRezultata(r[3].ToString());
            cijepanjeRezultata(r[4].ToString());
            FINALNI_REZULTAT = mem + FINALNI_REZULTAT;

            debug = FINALNI_REZULTAT;
        }
        string mem = ""; int mem_dodaj = 0; // cuva sledeci string za sabiranje
        private void cijepanjeRezultata(string unos){
            string a = ""; string b = "";
            if(unos.Length==velicina*2){
                a = unos.Substring(0, velicina); b = unos.Substring(velicina, velicina);
            } else {
                // Ukoliko nema velicina*2 cifara (cifre sa pocetka)
                int pomocnaVelicina = unos.Length - velicina;
                a = unos.Substring(0, pomocnaVelicina); b = unos.Substring(pomocnaVelicina, velicina);
            }

            if(mem==""){
                // Ukoliko je ovo prvi broj
                FINALNI_REZULTAT = b; mem = a;
            } else {
                BigInteger rezultat = BigInteger.Parse(mem) + BigInteger.Parse(b) + (BigInteger)mem_dodaj; mem_dodaj = 0;
                string rezultatS = rezultat.ToString();
                if(rezultatS.Length>velicina){
                    string brojBrisanje = rezultatS.Substring(0, rezultatS.Length - velicina); mem_dodaj = Convert.ToInt32(brojBrisanje);
                    rezultatS = rezultatS.Substring(rezultatS.Length - velicina, velicina);
                }
                FINALNI_REZULTAT = rezultatS + FINALNI_REZULTAT;
                mem = a;
            }
        }
#endregion

        public string dodajRazmak(string unos, int razmak = 3){
            string back = ""; int prosao = -1; 
            for(int i = unos.Length-1; i >= 0; i--){
                if(prosao==razmak) { back = " " + back; prosao = -1; }
                back = unos[i] + back;
                prosao++;
            }
            return back;
        }
    }
}
