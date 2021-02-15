using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Radio
{
    class Radio
    {
        static List<Uzenet> uzenetek = new List<Uzenet>();
        static void Main(string[] args)
        {
            Console.WriteLine("Adatok beolvasása...");
            Beolvas("veetel.txt");
            Console.WriteLine("Adatok beolvasva!");
            Console.WriteLine("\n2.feladat:");
            Console.WriteLine($"\tAz első üzenet rögzítője:{uzenetek.First().RadioAmator}");
            Console.WriteLine($"\tAz utolsó üzenet rögzítője:{uzenetek.Last().RadioAmator}");
            Console.WriteLine("\n3.feladat:");
            foreach (var item in uzenetek.FindAll(a => a.Szoveg.Contains("farkas")))
            {
                Console.WriteLine($"\t{item.Nap}. nap {item.RadioAmator}. rádióamatőr");
            }
            Console.WriteLine("\n4.feladat:");
            var statisztika =uzenetek.GroupBy(a => a.Nap).Select(b => new {nap = b.Key,db=b.Count()});
            for (int i = 1; i < 12; i++)
            {
                Console.WriteLine($"\t{i}. nap: {uzenetek.Where(a => a.Nap == i).Count()}");
            }
            Console.WriteLine("\n5.feladat:");
            using (StreamWriter sw=new StreamWriter("adaas.txt",true))
            {
                for (int nap = 1;nap < 12; nap++)
                {
                    char[] jo = new string(' ', 90).ToCharArray();
                    foreach (var item in uzenetek.FindAll(a => a.Nap == nap))
                    {
                        for (int j = 0; j < 90; j++)
                        {
                            if (item.Szoveg[j].Equals('$'))
                            {
                                break;
                            }
                            if (!item.Szoveg[j].Equals('#'))
                            {
                                jo[j] = item.Szoveg[j];
                            }
                        }
                    }
                    sw.WriteLine($"{nap}.nap {new string(jo)}");

                }
            }
            Console.WriteLine("\n7.feladat:");
            int nap2=SzamotBeker("Adja meg a nap sorszámát!  ",11);
            int azon=SzamotBeker("Adja meg a rádióamatőr sorszámát  ", 15);
            string uzenet = uzenetek.Find(a => a.Nap==nap2 && a.RadioAmator== azon).Szoveg;
            if (string.IsNullOrEmpty(uzenet))
            {
                Console.WriteLine("Nincs ilyen feljegyzés");
            }
            else if (uzenet.Contains("/"))
            {
                string[] sor = uzenet.Split('/');
                int felnott=0;
                if (!int.TryParse(sor[0], out felnott))
                {
                    Console.WriteLine("Nincs információ");
                }
                int kolyok;
                if (!int.TryParse(sor[1].Substring(0,1),out kolyok))
                {
                    Console.WriteLine("Nincs információ");
                }
                Console.WriteLine($"A megfigyelt egyedek száma:{felnott+kolyok}");
            }
            else
            {
                Console.WriteLine("Nincs információ");
            }

            Console.WriteLine("\nProgram Vége!");
            Console.ReadLine();
        }
        static void Beolvas(string fajl)
        {
            using (StreamReader sr=new StreamReader(fajl))
            {
                while (!sr.EndOfStream)
                {
                    int nap;
                    int azon;
                    string[] sor=sr.ReadLine().Split(' ');
                    nap = int.Parse(sor[0]);
                    azon = int.Parse(sor[1]);
                    uzenetek.Add(new Uzenet(nap,azon,sr.ReadLine()));

                }
            }
        }
        static bool szame(char[] szo)
        {
            bool valasz = true;
            for (int i = 0; i < szo.Length; i++)
            {
                if (szo[i]<'0' || szo[i]>'9')
                {
                    valasz = false;
                }
            }
            return valasz;
        }
        static int SzamotBeker(string kiiars,int max)
        {
            int szam = 0;
            do
            {
                Console.Write("\n"+kiiars);
            } while (!int.TryParse(Console.ReadLine(),out szam) || szam<1 || szam>max);
            return szam;
        }
    }
}
