using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitProba
{
    class Lakos
    {
        private string nev;
        private int kor;
        private string hely;
        private string kerulet;

        public Lakos(string sor)
        {
            string[] s = sor.Split(',');
            this.nev = s[0];
            this.kor = int.Parse(s[1]);
            this.hely = s[2];
            this.kerulet = s[3];
        }

        //getterek
        public string GetNev() { return nev; }
        public int GetKor() { return kor; }
        public string GetHely() { return hely; }
        public string GetKerulet() { return kerulet; }

    }
}
