using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    internal class Zvire
    {
        public string DruhZvirete;
        public string Jmeno;
        public bool Pohlavi; //true samec, false samicka
        public string PohlaviText;
        public int Hlad; // 0-10 - 0 je OK, 10 - umre hlady
        public int PotrebaSpanku; // 0-10 - 0 je OK, 10 - umre unavou, 7 a vic usina
        public int PotrebaHry; // 0-10 - 0 je OK, 10 - umre nudou
        public int PotrebaHovinka; // 0-5 - 0 je OK, 5 - umre zacpou
        public string Smrt;
        public bool Smrt2 = true;

        // Potreby budou generovane nahodne, nutny vypis info

        
        public Zvire()
        {   
            Random random = new Random();
            Pohlavi = random.Next(2) == 0;

            if (Pohlavi == true)
            {
                PohlaviText = "samec";
            }
            else 
            {  
                PohlaviText = "samice";
            }

            Console.WriteLine($"Vyber jmeno pro sve nove zviratko ({PohlaviText}):");
            Jmeno = Console.ReadLine();
            GeneracePotreb();

        }

        public void GeneracePotreb()
        {
            Random random = new Random();
            Hlad = random.Next(7);
            PotrebaSpanku = random.Next(7);
            PotrebaHry = random.Next(7);
            PotrebaHovinka = random.Next(3);
        }
   
        public string Info()
        {
            return $"Tve zvire je {DruhZvirete}, je to {PohlaviText} a jmenuje se {Jmeno}.";
        }
        public string Info2()
        {
           if (Hlad >= 10)
            {
                Smrt = "Zvire ti umrelo hlady.";
                Smrt2 = false;
            }
            else if (Hlad < -5)
            {
                Smrt = "Zvire ti umrelo prezranim.";
                Smrt2 = false;
            }
            else if (PotrebaSpanku >= 10)
            {
                Smrt = "Zvire ti umrelo vycerpanim.";
                Smrt2 = false;
            }
            else if (PotrebaSpanku > 6) 
            {
                Smrt = "Zvire ti usnulo.";
            }
           else if (PotrebaHry >= 10)
            {
                Smrt = "Zvire ti umrelo nudou.";
                Smrt2 = false;
            }
           else if (PotrebaHovinka >= 5)
            {
                Smrt = "Zvire ti umrelo na zauzleni stev.";
                Smrt2 = false;
            }
            return $"Potreba hladu je: {Hlad}/10, chce si hrat {PotrebaHry}/10, chce spat {PotrebaSpanku}/10 a potrebuje na zachod {PotrebaHovinka}/5.\n{Smrt}";
        }

      
        public void Akce(string volbaAkce)
        {
            Random random = new Random();
            Hlad += random.Next(-1, 2);
            PotrebaSpanku += random.Next(-1, 2);
            PotrebaHry += random.Next(-1, 2);
            PotrebaHovinka += random.Next(-1, 2);
            switch (volbaAkce)
            {
                case "1":
                    Hlad -= 4;
                    PotrebaHovinka+= 2;
                    break;
                case "2":
                    Console.WriteLine("Byla jednou jednou jedna zlata rybicka Zlatuska, pejsek Rek a zelva Zofka...");
                    PotrebaHry--;
                    PotrebaSpanku -= 2;
                    break;
                case "3":
                    PotrebaSpanku--;
                    break; 
                case "4":
                    PotrebaHovinka = 0;
                    Console.WriteLine("Zviratko se ti vyprazdnilo.");
                    PotrebaHry++;
                    break; 
                case "5":
                    if (DruhZvirete == "zelva")
                    {
                        PotrebaHry--;
                    }
                    else if (DruhZvirete == "pes")
                    {
                        PotrebaHry-=3;
                        Hlad += 2;
                        PotrebaHovinka++;
                        PotrebaSpanku++;
                    }
                    else if (DruhZvirete == "zlata rybka")
                    {
                        PotrebaHry++;
                    }
                        break;
                case "6":
                    PotrebaHovinka--;
                    if (DruhZvirete == "zelva")
                    {
                        PotrebaHry--;                        
                    }
                    else if (DruhZvirete == "pes")
                    {
                        PotrebaHry++;
                        PotrebaSpanku--;
                    }
                    else if (DruhZvirete == "zlata rybka")
                    {
                        PotrebaHry=0;
                        PotrebaSpanku++;
                        PotrebaHovinka--;
                    }
                    break;
                case "7":
                    Console.WriteLine("Zvire jsi zabil.");
                    Console.ReadLine();
                    Smrt2 = false;
                    break;
            }
            
        }
    }
}
