using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Sprava_skoleni
{
    class Program
    {

        /*static int zobrazVyberMenu(string nadpis, string[] polozkyMenu)
        {
            int volba = 0;
            Console.WriteLine("*MENU - {0}*", nadpis);

            while (volba <= 0 || volba > polozkyMenu.Length + 1)
            {
                for (int i = 0; i < polozkyMenu.Length; i++)
                {
                    Console.WriteLine("{0}.{1}", i + 1, polozkyMenu[i]);
                }
                Console.Write("Vasa volba:");
                try
                {
                    volba = Int32.Parse(Console.ReadLine());
                    if (volba <= 0 || volba > polozkyMenu.Length + 1)
                    {
                       throw new ArgumentOutOfRangeException();
                    }
                }
                catch(Exception chyba)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                }
            }
            return volba;
        }
        */

        static void Main(string[] args)
        {
            string cesta = "C:\\Users\\kocak\\Desktop\\Programming\\programovanie v C#\\Aplikacia1\\SavedFiles";
            Directory.SetCurrentDirectory(cesta);
            SpravaSkoleni spravaSkoleni = new SpravaSkoleni();
            spravaSkoleni.NacistZamestnance();
            spravaSkoleni.NacitajSkolenie();
            
            int volba = 0;
            while(volba != 7)
            {
                volba = spravaSkoleni.ZobrazVyberMenu("***Hlavne Menu***", new string[] { "Nove Skolenie", "Zoznam Skoleni", "Zoznam Studentov", "Zoznam Lektorov", "Vypis ladiaceho infa", "Uprav skolenie","Ukoncit program" });
                switch(volba)
                {
                    case 1:
                        spravaSkoleni.NoveSkolenie();
                        break;
                    case 2:
                        Skoleni vybraneSkolenie = spravaSkoleni.VybratSkolenie();
                        if(vybraneSkolenie != null)
                        {
                            int VolbaDetailSkolenia = 0;
                            while(VolbaDetailSkolenia != 6)
                            {
                                spravaSkoleni.ZobrazDetailSkolenia(vybraneSkolenie);
                                if(vybraneSkolenie.Uzavrene)
                                {
                                    Console.WriteLine("Toto skolenie je uzavrete!\nStistknutim lubovolnej klavesy pokracujete dalej");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    VolbaDetailSkolenia = spravaSkoleni.ZobrazVyberMenu("Skolenie", new string[] { "Prihlasit studenta", "Odhlasit studenta", "Prihlasit lektora", "Odhlasit lektora", "Uzavriet skolenie", "Zpet na hlavne menu"});
                                    switch(VolbaDetailSkolenia)
                                    {
                                        case 1:
                                            spravaSkoleni.PrihlasitStudenta(vybraneSkolenie);
                                            break;
                                        case 2:
                                            spravaSkoleni.OdhlasitStudenta(vybraneSkolenie);
                                            break;
                                        case 3:
                                            spravaSkoleni.PrihlasitLektora(vybraneSkolenie);
                                            break;
                                        case 4:
                                            spravaSkoleni.OdhlasitLektora(vybraneSkolenie);
                                            break;
                                        case 5:
                                            spravaSkoleni.UzavretieSkolenia(vybraneSkolenie);
                                            break;
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        spravaSkoleni.VyberStudenta();
                        break;
                    case 4:
                        spravaSkoleni.VyberLektora();
                        break;
                    case 5:
                        spravaSkoleni.VypisLadiciInfo();
                        break;
                    case 6:
                        spravaSkoleni.UpravSkolenie();
                        break;
                }
            }
            spravaSkoleni.UlozitSkolenie();
            Console.WriteLine("{0}", DateTime.Now.ToString("HH:mm:ss"));
            Console.ReadKey();
        }
    }
}
