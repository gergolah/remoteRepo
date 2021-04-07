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
            //mindenki 18 feletti?
            //ki lakik a XIII. kerületben?
            //milyen kerületekben laknak?
            //melyik kerületben hányan laknak?

            Console.ReadLine();
        }
    }
}
