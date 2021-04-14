using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitProba
{
    class Program
    {
        static void Main(string[] args)
        {
            //file beolvasás és tárolás
            List<Lakos> osszesLakos = new List<Lakos>();
            string[] beolvasas = File.ReadAllLines("lakosok.txt");

            foreach (string sor in beolvasas.Skip(1))
            {
                Lakos lakos = new Lakos(sor);
                osszesLakos.Add(lakos);
            }

            //adatok száma

            int N = osszesLakos.Count();

            //legnagyobb elem helye (legidősebb lakos)

            int korMaxIndex = 0;
            for (int i = 0; i < N; i++)
            {
                if (osszesLakos[i].GetKor() > osszesLakos[korMaxIndex].GetKor())
                {
                    korMaxIndex = i;
                }
            }
            string legidosebbLakos = osszesLakos[korMaxIndex].GetNev();

            //van budapesti lakos?

            bool vanBudapestiLakos = false;
            for (int i = 0; i < N; i++)
            {
                if (osszesLakos[i].GetHely() == "Budapest")
                {
                    vanBudapestiLakos = true;
                }
            }
            string kiiras = vanBudapestiLakos ? "van" : "nincs";
            //Console.WriteLine($"{kiiras} budapesti lakos");

            //mindenki 18 feletti?

            int j = 0;
            while (j < N && osszesLakos[j].GetKor() > 18)
            {
                j++;
            }
            bool mindenki18Feletti = j >= N;


            //ki lakik a XIII. kerületben?

            HashSet<string> XIIIkerületiLakosok = new HashSet<string>();
            for (int i = 0; i < N; i++)
            {
                if (osszesLakos[i].GetKerulet() == "XIII.")
                {
                    XIIIkerületiLakosok.Add(osszesLakos[i].GetNev());
                }
            }

            //milyen kerületekben laknak?

            HashSet<string> keruletek = new HashSet<string>();
            foreach (var item in osszesLakos)
            {
                if (item.GetKerulet() != "")
                {
                    keruletek.Add(item.GetKerulet());
                }
            }

            //melyik kerületben hányan laknak?

            Dictionary<string, int> holHanyanLaknak = new Dictionary<string, int>();
            foreach (var lakos in osszesLakos)
            {
                string kulcs = lakos.GetKerulet();
                if (kulcs == "")
                {
                    kulcs = "Nem budapesti";
                }
                if (holHanyanLaknak.ContainsKey(kulcs))
                {
                    holHanyanLaknak[kulcs]++;
                }
                else
                {
                    holHanyanLaknak.Add(kulcs, 1);
                }
            }
            foreach (var item in holHanyanLaknak)
            {
                Console.WriteLine($"{item.Key} kerületben ennyien laknak: {item.Value}");
            }

            //írjuk ki fileba a három legidősebb lakost!
            var lakosokSorrendbenLista = osszesLakos.OrderByDescending(x => x.GetKor()).ToList();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(lakosokSorrendbenLista[i].GetNev());
            }
            //string tömbbe írás
            //int tombHossz = 3;
            //string[] lakosokSorrendbenTomb = lakosokSorrendbenLista.Select(c => c.ToString()).ToArray();
            //for (int i = 0; i < tombHossz; i++)
            //{
            //    File.WriteAllLines("harom_legidosebb_lakos.txt", lakosokSorrendbenTomb);
            //}

            Console.ReadLine();
        }
    }
}
