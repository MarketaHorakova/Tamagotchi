using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ukol starat se o domaci zvire - zije max. 20-25 dni
// vyvoj, jidlo, hra
// zvire rado umira

// zvirata: zelva, pes, ryba
// vlastnosti: jmeno, pohlavi, druh zradla, potreba spanku, potreba hry, vyprazdnovani

namespace Tamagotchi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ahoj, vitej ve svete Tamagotchi. O jake zviratko se chces starat? \nMas na vyber:\n1) Zelva\n2) Pes\n3) Zlata rybka");
            string zvireVyber = Console.ReadLine();
            Zvire zvire = new Zvire();

            if (zvireVyber == "1" || zvireVyber == "zelva" || zvireVyber == "Zelva")
            {
                zvire.DruhZvirete = "zelva";
            }
            else if (zvireVyber == "2" || zvireVyber == "pes" || zvireVyber == "Pes")
            {
                zvire.DruhZvirete = "pes";
            }
            else if (zvireVyber == "3" || zvireVyber == "ryba" || zvireVyber == "Ryba")
            {
                zvire.DruhZvirete = "zlata rybka";
            }
            else
            {
                Console.WriteLine("Nevybral jsi nic.");
            }
            Console.WriteLine(zvire.Info());

            while (zvire.Smrt2)
            {
                Console.WriteLine(zvire.Info2());
                if (zvire.Smrt2 == true) 
                { 
                Console.WriteLine("Zvol akci (cislem): \n1) Krmit \n2) Precist pohadku \n3) Probudit \n4) Hladit brisko \n5) Hodit mic \n6) Podrbat na hrbete \n7) Zabit");
                }
                zvire.Akce(Console.ReadLine());
            }

        }
    }
}
