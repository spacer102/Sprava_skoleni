using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprava_skoleni
{
    class SpravaSkoleni
    {
        //@"C:\Users\kocak\Desktop\Programovanie\programovanie v C#\Aplikacia1\Sprava_skoleni\Skoleni.txt"
        //string cesta = "C:\\Users\\kocak\\Desktop\\Programovanie\\programovanie v C#\\Aplikacia1\\SavedFiles";
        //Directory.SetCurrentDirectory(cesta);

        private const string suborZamestnanci = "zamestnanci.txt";
        private const string suborSkolenie = "Skoleni.txt";

        public List <Lektor> Lektori { get; set; }

        public List <Student> Studenti { get; set; }

        public List <Skoleni> ZoznamSkoleni { get; set; }

        public SpravaSkoleni()
        {
            Lektori = new List<Lektor>();
            Studenti = new List<Student>();
            ZoznamSkoleni = new List<Skoleni>();
        }

        public Student NajdiStudentaPodlaKodu(string kod)
        {
            foreach(Student student in Studenti)
            {
                if(student.Kod == kod)
                {
                    return student;
                }
            }
            return null;
        }

        public Lektor NajdiLektoraPodlaKodu(string kod)
        {
            foreach (Lektor lektor in Lektori)
            {
                if (lektor.Kod == kod)
                {
                    return lektor;
                }
            }
            return null;
        }

        public void VyberStudenta()
        {
            int volba = -1;
            
            while (true)
            {
                try
                {
                    int counter = 0;
                    foreach (Student student in Studenti)
                    {
                        counter += 1;
                        Console.WriteLine("{0}.{1} {2} ({3})", counter, student.Meno, student.Priezvisko, student.Nazov_pozicie);
                    }
                    Console.WriteLine("0.Zpet");

                    Console.WriteLine("Vasa volba: ");
                    volba = Int32.Parse(Console.ReadLine())-1;

                    if (volba < -1 || volba > Studenti.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;
                }
                catch (Exception err)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", err.Message);
                }
            }

            if (volba != -1)
            {
                Console.WriteLine("Uzatvorene skolenia: ");
                int i = 0;
                foreach (Skoleni skolenia in Studenti[volba].Skolenie)
                {
                    if (skolenia.Uzavrene == true)
                    {
                        i += 1;
                        Console.WriteLine("{0}.{1}", i, skolenia.Nazov);
                        if (skolenia.Slovny_komentar_hodnotenia[Studenti[volba]] != null)
                        {
                            Console.WriteLine("\t{0}%  Komentar: {1}", skolenia.Hodnotenie_studentov[Studenti[volba]], skolenia.Slovny_komentar_hodnotenia[Studenti[volba]]);
                        }
                        if (skolenia.Slovny_komentar_hodnotenia[Studenti[volba]] == null)
                        {
                            Console.WriteLine("\t{0}%", skolenia.Hodnotenie_studentov[Studenti[volba]]);
                        }
                    }
                }

                if(i==0)
                {
                    Console.WriteLine("ZIADNE UZATVORENE SKOLENIA!");
                }

                Console.WriteLine("***OTVORENE SKOLENIA***");

                i = 0;
                int x = 0;
                List<string> ZapisaneSkoleniaJe = new List<string>();
                List<string> ZapisaneSkolenia = new List<string>();

                foreach(Skoleni skolenia in ZoznamSkoleni)
                {
                    if(skolenia.Uzavrene == false && !skolenia.Studenti.Contains(Studenti[volba]))
                    {
                        i += 1;
                        string daco = skolenia.Nazov.ToString();
                        ZapisaneSkoleniaJe.Add(daco);
                    }
                    if (skolenia.Uzavrene == false && skolenia.Studenti.Contains(Studenti[volba]))
                    {
                        x += 1;
                        string picovina = skolenia.Nazov.ToString();
                        ZapisaneSkolenia.Add(picovina);
                    }
                }

                if (i==0)
                {
                    Console.WriteLine("ZIADNE OTVORENE SKOLENIA UZ NIESU DOSTUPNE NA PRIHLASENIE");
                }
                if(i>0)
                {
                    Console.WriteLine("Otvorene skolenia na ktorych nie je student este zapisany: ");
                    for (int a=0; a<= ZapisaneSkoleniaJe.Count-1; a++)
                    {
                        Console.WriteLine("{0}.{1}", a+1, ZapisaneSkoleniaJe[a]);
                    }
                }
                                
                if (x==0)
                {
                    Console.WriteLine("STUDENT NENI ESTE NA ZIADNOM OTVORENOM SKOLENI!");
                }
                else if(x>0)
                {
                    Console.Write("\n");
                    Console.WriteLine("Student je uz zapisany na tychto skoleniach: ");
                    for (int b = 0; b <= ZapisaneSkolenia.Count-1; b++)
                    {
                        Console.WriteLine("{0}.{1}", b+1, ZapisaneSkolenia[b]);
                    }
                }
                Console.Write("\n\n");
            }
        }

        public void VyberLektora()
        {
            int volba = -1;
            
            while (true)
            {
                try
                {
                    int counter = 0;
                    foreach (Lektor lektor in Lektori)
                    {
                        counter += 1;
                        Console.WriteLine("{0}.{1} {2} ({3})", counter, lektor.Meno, lektor.Priezvisko, lektor.Nazov_pozicie);
                    }
                    Console.WriteLine("0.Zpet");

                    Console.WriteLine("Vasa volba: ");
                    volba = Int32.Parse(Console.ReadLine()) - 1;

                    if (volba < -1 || volba > Lektori.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;
                }
                catch (Exception err)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", err.Message);
                }
            }

            if (volba != -1)
            {
                Console.WriteLine("\nUzatvorene skolenia: ");
                int i = 0;
                foreach (Skoleni skolenia in Lektori[volba].VyucovanaSkoleni)
                {
                    if (skolenia.Uzavrene == true)
                    {
                        i += 1;
                        Console.WriteLine("{0}.{1}", i, skolenia.Nazov);
                    }
                }
                if (i == 0)
                {
                    Console.WriteLine("ZIADNE UZATVORENE SKOLENIA!");
                }



                Console.WriteLine("\nOtvorene skolenia: ");
                i = 0;
                foreach (Skoleni skolenia in Lektori[volba].VyucovanaSkoleni)
                {
                    if (skolenia.Uzavrene == false)
                    {
                        i += 1;
                        Console.WriteLine("{0}.{1}", i, skolenia.Nazov);
                    }
                }
                if (i == 0)
                {
                    Console.WriteLine("ZIADNE OTVORENE SKOLENIA!");
                }



                Console.WriteLine("\n***SKOLENIA NA KTORYCH LEKTOR ESTE NIE JE ZAPISANY A SU OTVORENE***");
                i = 0;
                foreach (Skoleni skolenia in ZoznamSkoleni)
                {
                    if (skolenia.Uzavrene == false && !skolenia.Lektori.Contains(Lektori[volba]))
                    {
                        i += 1;
                        Console.WriteLine("{0}.{1}", i, skolenia.Nazov);
                    }
                }
                if (i == 0)
                {
                    Console.WriteLine("ZIADNE SKOLENIA NA KTORE SA MOZE LEKTOR PRIHLASIT!");
                }

                Console.Write("\n\n");
            }
        }

        public void NacistZamestnance()
        {
            StreamReader citac = new StreamReader(suborZamestnanci);
            string riadok = citac.ReadLine();

            while ((riadok = citac.ReadLine()) != null)
            {
                var hodnoty = riadok.Split(';');
                string kod = hodnoty[0];
                string meno = hodnoty[1];
                string priezvisko = hodnoty[2];
                string nazovPozicie = hodnoty[3];
                string anoNie = hodnoty[4].ToLower();
                bool jeLektor = false;
                
                if(anoNie == "ano")
                {
                    jeLektor = true;
                }

                if(jeLektor == true)
                {
                    Lektor lektor = new Lektor(meno, priezvisko, kod, nazovPozicie);
                    Lektori.Add(lektor);
                }
                else if(jeLektor == false)
                {
                    Student student = new Student(meno, priezvisko, kod, nazovPozicie);
                    Studenti.Add(student);
                }
            }
            citac.Close();
        }

        public void VypisLadiciInfo()
        {
            Console.WriteLine("******SPRAVA SKOLENI******");
            Console.WriteLine("Pocet Lektorov :{0}\nPocet studentov:{1}", Lektori.Count, Studenti.Count);

            Console.WriteLine("\n******Lektori******\n");
            foreach(Lektor lektor in Lektori)
            {
                Console.WriteLine("{0} {1}", lektor.Meno, lektor.Priezvisko);
                Console.WriteLine("\tKod: {0}", lektor.Kod);
                Console.WriteLine("\tNazov pozicie: {0}", lektor.Nazov_pozicie);
            }

            Console.WriteLine("\n*****Studenti*****\n");
            foreach(Student student in Studenti)
            {
                Console.WriteLine("{0} {1}", student.Meno, student.Priezvisko);
                Console.WriteLine("\tKod: {0}", student.Kod);
                Console.WriteLine("\tNazov pozicie : {0}", student.Nazov_pozicie);
            }

            Console.WriteLine("\n*****Skolenia*****\n");
            foreach (Skoleni skolenie in ZoznamSkoleni)
            {
                Console.WriteLine("Nazov skolenia: {0}", skolenie.Nazov);
                Console.WriteLine("\tUzavrene: {0}", skolenie.Uzavrene);
                Console.WriteLine("\tPopis: {0}", skolenie.Popis);
                Console.WriteLine("\tDoporuceny pocet ucastnikov: {0}", skolenie.DoporucenyPocetUcastniku);
                Console.WriteLine("\tDatum konania: {0} - {1}", skolenie.PociatocneDatum.ToShortDateString(), skolenie.KoncoveDatum.ToShortDateString());

                Console.WriteLine("\tLektori: ");
                foreach(Lektor lektor in skolenie.Lektori)
                {
                    Console.WriteLine("\t\t{0} {1} ({2})", lektor.Meno, lektor.Priezvisko, lektor.Kod);
                }

                Console.WriteLine("\tStudenti: ");
                foreach(Student student in skolenie.Studenti)
                {
                    if((skolenie.Uzavrene == true) && (skolenie.Slovny_komentar_hodnotenia[student] == null))
                    {
                        Console.WriteLine("\t\t{0} {1} ({2}) - {3}%", student.Meno, student.Priezvisko, student.Kod, skolenie.Hodnotenie_studentov[student]);
                    }
                    if((skolenie.Uzavrene == true) && (skolenie.Slovny_komentar_hodnotenia[student] != null))
                    {
                        Console.WriteLine("\t\t{0} {1} ({2}) - {3}%\n\t\tkomentar:\t{4}", student.Meno, student.Priezvisko, student.Kod, skolenie.Hodnotenie_studentov[student], skolenie.Slovny_komentar_hodnotenia[student]);
                    }
                    if(skolenie.Uzavrene == false)
                    {
                        Console.WriteLine("\t\t{0} {1} ({2})", student.Meno, student.Priezvisko, student.Kod);
                    }
                }
            }
        }

        public void NacitajSkolenie()
        {
            StreamReader citac = new StreamReader(suborSkolenie);
            citac.ReadLine();
            string riadok = "";

            while((riadok = citac.ReadLine()) != null)
            {
                var informaciaSkolenia = riadok.Split(';');
                string nazov = informaciaSkolenia[0];
                string popis = informaciaSkolenia[1];

                var zaciatokDatumuSlozky = informaciaSkolenia[2].Split('.');
                DateTime zaciatokDatum = new DateTime(Int32.Parse(zaciatokDatumuSlozky[2]),
                    Int32.Parse(zaciatokDatumuSlozky[1]),
                    Int32.Parse(zaciatokDatumuSlozky[0]));

                var koniecDatumuSlozky = informaciaSkolenia[3].Split('.');
                DateTime koniecDatum = new DateTime(Int32.Parse(koniecDatumuSlozky[2]),
                    Int32.Parse(koniecDatumuSlozky[1]),
                    Int32.Parse(koniecDatumuSlozky[0]));

                int doporucenyPocetUcastnikov = Int32.Parse(informaciaSkolenia[4]);

                bool skolenieUzavrene = false;
                if(informaciaSkolenia[5] == "ANO")
                {
                    skolenieUzavrene = true;
                }

                citac.ReadLine();

                List<Lektor> lektori = new List<Lektor>();
                while((riadok = citac.ReadLine()) != "STUDENTI")
                {
                    lektori.Add(NajdiLektoraPodlaKodu(riadok));
                }

                List<Student> studenti = new List<Student>();
                while((riadok = citac.ReadLine()) != "HODNOTENIE")
                {
                    studenti.Add(NajdiStudentaPodlaKodu(riadok));
                }

                Dictionary<Student, int> hodnotenie = new Dictionary<Student, int>();
                Dictionary<Student, string> slovny_komentar = new Dictionary<Student, string>();

                while ((riadok = citac.ReadLine()) != "SKOLENIE")
                {
                    //riadok = citac.ReadLine();
                    if (riadok == null || riadok == "HODNOTENIE")
                    {
                        break;
                    }
                    if (riadok != "")
                    {
                        var hodnotyHodnotenia = riadok.Split(';');
                        hodnotenie.Add(NajdiStudentaPodlaKodu(hodnotyHodnotenia[0]), Int32.Parse(hodnotyHodnotenia[1]));
                        if (hodnotyHodnotenia.Count() > 2)
                        { 
                            slovny_komentar.Add(NajdiStudentaPodlaKodu(hodnotyHodnotenia[0]), hodnotyHodnotenia[2]);
                        }
                        else
                        {
                            slovny_komentar.Add(NajdiStudentaPodlaKodu(hodnotyHodnotenia[0]), null);
                        }
                    }
                           
                }

                Skoleni skoleni = new Skoleni(nazov, popis, zaciatokDatum, koniecDatum, studenti, lektori,
                    hodnotenie, slovny_komentar, doporucenyPocetUcastnikov, skolenieUzavrene);

                foreach(Student student in studenti)
                {
                    student.Skolenie.Add(skoleni);
                }

                foreach(Lektor lektor in lektori)
                {
                    lektor.VyucovanaSkoleni.Add(skoleni);
                }
                ZoznamSkoleni.Add(skoleni);
                }
            citac.Close();
        }

        public void NoveSkolenie()
        {
            Console.WriteLine("***Vytvaranie noveho skolenia***");
            Console.Write("Nazov: ");
            string nazov = Console.ReadLine();
            Console.Write("Popis: ");
            string popis = Console.ReadLine();
            Console.Write("Max počet ucastnikov: ");
            int dpc = Int32.Parse(Console.ReadLine());

            Console.WriteLine("pociatocny datum");
            Console.Write("\tDen: ");
            int pocDatDen = Int32.Parse(Console.ReadLine());
            Console.Write("\tMesiac: ");
            int pocDatMes = Int32.Parse(Console.ReadLine());
            Console.Write("\tRok: ");
            int pocDatRok = Int32.Parse(Console.ReadLine());
            DateTime pociatocnyDatum = new DateTime(pocDatRok, pocDatMes, pocDatDen);

            Console.WriteLine("Koncovy datum");
            Console.Write("\tDen: ");
            int konDatDen = Int32.Parse(Console.ReadLine());
            Console.Write("\tMesiac: ");
            int konDatMes = Int32.Parse(Console.ReadLine());
            Console.Write("\tRok: ");
            int konDatRok = Int32.Parse(Console.ReadLine());
            DateTime koncovyDatum = new DateTime(konDatRok, konDatMes, konDatDen);

            Skoleni skoleni = new Skoleni(nazov, popis, pociatocnyDatum, koncovyDatum, new List<Student>(), new List<Lektor>(),
                new Dictionary<Student, int>(), new Dictionary<Student, string>(), dpc, false);
            ZoznamSkoleni.Add(skoleni);
            UlozitSkolenie();
            Console.Write("***Skolenie vytvorene***");
        }

        public void UlozitSkolenie()
        {
            StreamWriter zapisovac = new StreamWriter(suborSkolenie);
            foreach(Skoleni skolenie in ZoznamSkoleni)
            {
               
                string pociatocnyDatum = String.Format("{0}.{1}.{2}", skolenie.PociatocneDatum.Day, skolenie.PociatocneDatum.Month, skolenie.PociatocneDatum.Year);
                string koncovyDatum = String.Format("{0}.{1}.{2}", skolenie.KoncoveDatum.Day, skolenie.KoncoveDatum.Month, skolenie.KoncoveDatum.Year);
                string uzavrete = "NIE";
                if(skolenie.Uzavrene)
                {
                    uzavrete = "ANO";
                }
                zapisovac.WriteLine("SKOLENIE");
                zapisovac.WriteLine("{0};{1};{2};{3};{4};{5}", skolenie.Nazov, skolenie.Popis, pociatocnyDatum, koncovyDatum, skolenie.DoporucenyPocetUcastniku, uzavrete);
                
                zapisovac.WriteLine("LEKTORI");
                foreach(Lektor lektor in skolenie.Lektori)
                {
                    zapisovac.WriteLine(lektor.Kod);
                }

                zapisovac.WriteLine("STUDENTI");
                foreach (Student student in skolenie.Studenti)
                {
                    zapisovac.WriteLine(student.Kod);
                }

                zapisovac.WriteLine("HODNOTENIE");
                foreach(Student student in skolenie.Hodnotenie_studentov.Keys)
                {
                    if (skolenie.Slovny_komentar_hodnotenia[student] == null)
                    {
                        zapisovac.WriteLine("{0};{1}", student.Kod, skolenie.Hodnotenie_studentov[student]);
                    }
                    if (skolenie.Slovny_komentar_hodnotenia[student] != null)
                    {
                        zapisovac.WriteLine("{0};{1};{2}", student.Kod, skolenie.Hodnotenie_studentov[student], skolenie.Slovny_komentar_hodnotenia[student]);
                    }
                }
            }
            zapisovac.Close();
        }

        public Skoleni VybratSkolenie()
        {
            int volba=-1;
            Console.WriteLine("***ZOZNAM SKOLENI***");
             
            while (true)
            {
                for (int i = 0; i < ZoznamSkoleni.Count; i++)
                {
                    string stav = "otvoreny";
                    if (ZoznamSkoleni[i].Uzavrene)
                    {
                        stav = "uzavreny";
                    }
                    Console.WriteLine("{0}. {1} - {2}", i + 1, ZoznamSkoleni[i].Nazov, stav);
                }
                try
                {
                    Console.WriteLine("0. zpet");
                    Console.Write("Vasa volba:");
                    volba = Int32.Parse(Console.ReadLine()) - 1;
                    if (volba >= 0 && volba < ZoznamSkoleni.Count)
                    {
                        return ZoznamSkoleni[volba];
                    }
                    if (volba <= -2 || volba >= ZoznamSkoleni.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception chyba)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                }
            }
        }
        
        public void ZobrazDetailSkolenia(Skoleni skolenie)
        {
            string stav = "Otvorene";
            if(skolenie.Uzavrene)
            {
                stav = "Uzavrene";
            }

            Console.WriteLine("***Detail skolenia***");
            Console.WriteLine("Nazov skolenia: {0} ", skolenie.Nazov);
            Console.WriteLine("\tStav: {0}", stav);
            Console.WriteLine("\tPopis: {0}", skolenie.Popis);
            Console.WriteLine("\tDoporuceny pocet ucastnikov: {0}", skolenie.DoporucenyPocetUcastniku);
            Console.WriteLine("\tDatum konania: {0} - {1} ", skolenie.PociatocneDatum.ToShortDateString(), skolenie.KoncoveDatum.ToShortDateString());

            Console.WriteLine("\tLektori: ");
            foreach (Lektor lektor in skolenie.Lektori)
            {
                Console.WriteLine("\t\t{0} {1} ({2})", lektor.Meno, lektor.Priezvisko, lektor.Kod);
            }

            Console.WriteLine("\tStudenti: ");
            foreach (Student student in skolenie.Studenti)
            {
                if ((skolenie.Uzavrene == true) && (skolenie.Slovny_komentar_hodnotenia[student] == null))
                {
                    Console.WriteLine("\t\t{0} {1} ({2}) - {3}%", student.Meno, student.Priezvisko, student.Kod, skolenie.Hodnotenie_studentov[student]);
                }
                if ((skolenie.Uzavrene == true) && (skolenie.Slovny_komentar_hodnotenia[student] != null))
                {
                    Console.WriteLine("\t\t{0} {1} ({2}) - {3}%\n\t\tkomentar:\t{4}", student.Meno, student.Priezvisko, student.Kod, skolenie.Hodnotenie_studentov[student], skolenie.Slovny_komentar_hodnotenia[student]);
                }
                if(skolenie.Uzavrene == false)
                {
                    Console.WriteLine("\t\t{0} {1} ({2})", student.Meno, student.Priezvisko, student.Kod);
                }
            }
        }

        public void UpravSkolenie()
        {
            int sekitejn = 0;
            int volba;
            List<Skoleni> SoznamSkoleni = new List<Skoleni>();
            Skoleni skoleni;
            Console.WriteLine("***ZOZNAM SKOLENI***");

            while (true)
            {

                while (true)
                {
                    try
                    {
                        int pocitadlo = 0;
                        for (int i = 0; i < ZoznamSkoleni.Count; i++)
                        {
                            if (ZoznamSkoleni[i].Uzavrene == false)
                            {
                                pocitadlo += 1;
                                Console.WriteLine("{0}. {1} - Otvorene", pocitadlo, ZoznamSkoleni[i].Nazov);
                                if (sekitejn == 0)
                                {
                                    SoznamSkoleni.Add(ZoznamSkoleni[i]);
                                }
                            }
                        }

                        if(pocitadlo==0)
                        {
                            Console.WriteLine("NENASLI SA ZIADNE OTVORENE SKOLENIA!");
                        }

                        sekitejn += 1;
                        Console.WriteLine("0. zpet");
                        Console.Write("Vasa volba:");
                        volba = Int32.Parse(Console.ReadLine()) - 1;
                        if (volba >= 0 && volba < SoznamSkoleni.Count)
                        {
                            break;
                        }
                        if (volba <= -2 || volba >= SoznamSkoleni.Count)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        else
                        {
                            volba = -1;
                            break;
                        }
                    }
                    catch (Exception chyba)
                    {
                        Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                    }
                }

                while (volba != -1 && volba != -2)
                {
                    skoleni = SoznamSkoleni[volba];
                    Console.WriteLine("\t{0}", skoleni.Nazov);
                    int vyber = ZobrazVyberMenu("Menu Upravy Skolenia", new string[] { "Zmenit nazov skolenia", "Zmenit popis skolenia", "Zmenit doporuceny pocet ucastnikov", "Zmenit zaciatocny datum", "Zmenit koncovy datum", "Navrat do hlavneho menu", "Zpet" });

                    switch (vyber)
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("Sucasny nazov skolenia:\n\t{0}", skoleni.Nazov);
                                Console.WriteLine("Zadaj novy nazov skolenia:");
                                skoleni.Nazov = Console.ReadLine();
                            }
                            catch (Exception chyba)
                            {
                                Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                            }
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("Sucasny popis skolenia:\n\t{0}", skoleni.Popis);
                                Console.WriteLine("Zadaj novy popis skolenia:");
                                skoleni.Popis = Console.ReadLine();
                            }
                            catch (Exception chyba)
                            {
                                Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                            }
                            break;
                        case 3:
                            try
                            {
                                Console.WriteLine("Sucasny doporuceny pocet ucastnikov skolenia:\n\t{0}", skoleni.DoporucenyPocetUcastniku);
                                Console.WriteLine("Zadaj novy doporuceny pocet ucastnikov skolenia:");
                                int pocetUcastnikov = Int32.Parse(Console.ReadLine());
                                if(pocetUcastnikov<=0)
                                {
                                    throw new ArgumentOutOfRangeException();
                                }
                                skoleni.DoporucenyPocetUcastniku = pocetUcastnikov;
                            }
                            catch (Exception chyba)
                            {
                                Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                            }
                            break;
                        case 4:
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("***pociatocny datum***");
                                    Console.WriteLine("\n\tSucasny Pociatocny datum: {0}.{1}.{2}\n", skoleni.PociatocneDatum.Day, skoleni.PociatocneDatum.Month, skoleni.PociatocneDatum.Year);
                                    Console.WriteLine("Co chces zmenit?\n1.den\n2.mesiac\n3.rok\n4.zpet");
                                    int arizona = Int32.Parse(Console.ReadLine());

                                    switch (arizona)
                                    {
                                        case 1:
                                            Console.WriteLine("\tDen: ");
                                            int pocDatDen = Int32.Parse(Console.ReadLine());
                                            int pocDatMes = skoleni.PociatocneDatum.Date.Month;
                                            int pocDatRok = skoleni.PociatocneDatum.Date.Year;

                                            DateTime pociatocnyDatum = new DateTime(pocDatRok, pocDatMes, pocDatDen);
                                            skoleni.PociatocneDatum = pociatocnyDatum;
                                            break;
                                        case 2:
                                            Console.WriteLine("\tMesiac: ");
                                            pocDatDen = skoleni.PociatocneDatum.Date.Day;
                                            pocDatMes = Int32.Parse(Console.ReadLine());
                                            pocDatRok = skoleni.PociatocneDatum.Date.Year;

                                            pociatocnyDatum = new DateTime(pocDatRok, pocDatMes, pocDatDen);
                                            skoleni.PociatocneDatum = pociatocnyDatum;
                                            break;
                                        case 3:
                                            Console.WriteLine("\tRok: ");
                                            pocDatDen = skoleni.PociatocneDatum.Date.Day;
                                            pocDatMes = skoleni.PociatocneDatum.Date.Month;
                                            pocDatRok = Int32.Parse(Console.ReadLine());

                                            pociatocnyDatum = new DateTime(pocDatRok, pocDatMes, pocDatDen);
                                            skoleni.PociatocneDatum = pociatocnyDatum;
                                            break;
                                    }
                                    if(arizona==4)
                                    {
                                        break;
                                    }
                                }
                                catch (Exception chyba)
                                {
                                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                                }
                            }
                            break;
                        case 5:
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("***Koncovy datum***");
                                    Console.WriteLine("\n\tSucasny koncovy datum: {0}.{1}.{2}\n", skoleni.KoncoveDatum.Day, skoleni.KoncoveDatum.Month, skoleni.KoncoveDatum.Year);
                                    Console.WriteLine("Co chces zmenit?\n1.den\n2.mesiac\n3.rok\n4.zpet");
                                    int arizona = Int32.Parse(Console.ReadLine());

                                    switch (arizona)
                                    {
                                        case 1:
                                            Console.WriteLine("\tDen: ");
                                            int konDatDen = Int32.Parse(Console.ReadLine());
                                            int konDatMes = skoleni.KoncoveDatum.Date.Month;
                                            int konDatRok = skoleni.KoncoveDatum.Date.Year;

                                            DateTime koncovyDatum = new DateTime(konDatRok, konDatMes, konDatDen);
                                            skoleni.KoncoveDatum = koncovyDatum;
                                            break;
                                        case 2:
                                            Console.WriteLine("\tMesiac: ");
                                            konDatDen = skoleni.PociatocneDatum.Date.Day;
                                            konDatMes = Int32.Parse(Console.ReadLine());
                                            konDatRok = skoleni.PociatocneDatum.Date.Year;

                                            koncovyDatum = new DateTime(konDatRok, konDatMes, konDatDen);
                                            skoleni.KoncoveDatum = koncovyDatum;
                                            break;
                                        case 3:
                                            Console.WriteLine("\tRok: ");
                                            konDatDen = skoleni.PociatocneDatum.Date.Day;
                                            konDatMes = skoleni.PociatocneDatum.Date.Month;
                                            konDatRok = Int32.Parse(Console.ReadLine());

                                            koncovyDatum = new DateTime(konDatRok, konDatMes, konDatDen);
                                            skoleni.KoncoveDatum = koncovyDatum;
                                            break;
                                    }
                                    if (arizona == 4)
                                    {
                                        break;
                                    }
                                }
                                catch (Exception chyba)
                                {
                                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                                }
                            }
                            break;
                        case 6:
                            volba = -1;
                            break;
                        case 7:
                            volba = -2;
                            break;
                    }
                }

                if (volba == -1)
                {
                    break;
                }
            }
            UlozitSkolenie();
        }

        public void PrihlasitStudenta(Skoleni skolenie)
        {
            List<Student> studenti = new List<Student>();
            foreach(Student student in Studenti)
            {
                if(!skolenie.Studenti.Contains(student))
                {
                    studenti.Add(student);
                }
            }
            Console.WriteLine("***Prihlasenie studenta na skolenie***");

            int volba = VyberStudenta(studenti);

            if(volba >= 0 && volba < studenti.Count)
            {
                skolenie.Studenti.Add(studenti[volba]);
                UlozitSkolenie();
                Console.WriteLine("Student ulozeny!");
            }
        }

        private int VyberStudenta(List<Student> studenti)
        {
            int volba = -1;

            while (volba < 0 || volba >= studenti.Count)
            {
                try
                {
                    for (int i = 0; i < studenti.Count; i++)
                    {
                        Console.WriteLine("{0}. {1} {2} ({3})", i + 1, studenti[i].Meno, studenti[i].Priezvisko, studenti[i].Kod);
                    }
                    Console.WriteLine("0. Zpet");
                    Console.Write("Vyber studenta: ");

                    volba = Int32.Parse(Console.ReadLine()) - 1;
                    if (volba == -1)
                    {
                        return volba;
                    }
                    if (volba <= 0 || volba > studenti.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception chyba)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                }
            }
            return volba;
        }

        public void OdhlasitStudenta(Skoleni skolenie)
        {
            Console.WriteLine("***Odhlasenie studenta na skolenie***");
            int volba = -1;

            while (volba < 0 || volba >= skolenie.Studenti.Count)
            {
                try
                {
                    for (int i = 0; i < skolenie.Studenti.Count; i++)
                    {
                        Console.WriteLine("{0}. {1} {2} ({3})", i + 1, skolenie.Studenti[i].Meno, skolenie.Studenti[i].Priezvisko, skolenie.Studenti[i].Kod);
                    }
                    Console.WriteLine("0. Zpet");
                    Console.Write("Vyber studenta: ");

                    volba = Int32.Parse(Console.ReadLine()) - 1;
                    if (volba == -1)
                    {
                         break;
                    }
                    if (volba <= 0 || volba > skolenie.Studenti.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception chyba)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                }
            }

            if (volba >= 0 && volba < skolenie.Studenti.Count)
            {
                skolenie.Studenti.Remove(skolenie.Studenti[volba]);
                UlozitSkolenie();
                Console.WriteLine("Student odhlaseny!");
            }
        }

        public void PrihlasitLektora(Skoleni skolenie)
        {
            List<Lektor> lektori = new List<Lektor>();
            foreach (Lektor lektor in Lektori)
            {
                if (!skolenie.Lektori.Contains(lektor))
                {
                    lektori.Add(lektor);
                }
            }

            Console.WriteLine("***Prihlasenie lektora na skolenie***");
            int volba = VyberLektora(lektori);
 
            if (volba >= 0 && volba < lektori.Count)
            {
                skolenie.Lektori.Add(lektori[volba]);
                UlozitSkolenie();
                Console.WriteLine("Lektor ulozeny!");
            }
        }

        private int VyberLektora(List<Lektor> lektori)
        {
            int volba = -1;

            while (volba < 0 || volba >= lektori.Count)
            {
                try
                {
                    for (int i = 0; i < lektori.Count; i++)
                    {
                        Console.WriteLine("{0}. {1} {2} ({3})", i + 1, lektori[i].Meno, lektori[i].Priezvisko, lektori[i].Kod);
                    }
                    Console.WriteLine("0. Zpet");
                    Console.Write("Vyber lektora: ");

                    volba = Int32.Parse(Console.ReadLine()) - 1;
                    if (volba == -1)
                    {
                        return volba;
                    }
                    if (volba <= 0 || volba > lektori.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception chyba)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                }
            }
            return volba;
        }

        public void OdhlasitLektora(Skoleni skolenie)
        {
            Console.WriteLine("***Odhlasenie lektora na skolenie***");
            int volba = -1;

            while (volba < 0 || volba >= skolenie.Lektori.Count)
            {
                try
                {
                    for (int i = 0; i < skolenie.Lektori.Count; i++)
                    {
                        Console.WriteLine("{0}. {1} {2} ({3})", i + 1, skolenie.Lektori[i].Meno, skolenie.Lektori[i].Priezvisko, skolenie.Lektori[i].Kod);
                    }
                    Console.WriteLine("0. Zpet");
                    Console.Write("Vyber lektora: ");

                    volba = Int32.Parse(Console.ReadLine()) - 1;
                    if (volba == -1)
                    {
                        break;
                    }
                    if (volba <= 0 || volba > skolenie.Lektori.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception chyba)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                }
            }

            if (volba >= 0 && volba < skolenie.Lektori.Count)
            {
                skolenie.Lektori.Remove(skolenie.Lektori[volba]);
                UlozitSkolenie();
                Console.WriteLine("Lektor uspesne odhlaseny!");
            }
        }

        public void UzavretieSkolenia(Skoleni skolenie)
        {
            Console.WriteLine("***Uzavretie skolenia***");
            Console.WriteLine("Vyplnte hodnotenie studentov");
            foreach(Student zdenka in skolenie.Studenti)
            {
                Console.WriteLine("{0} {1} ({2})", zdenka.Meno, zdenka.Priezvisko, zdenka.Kod);
                int hodnotenie=-1;

                while (true)
                {
                    try
                    {
                        hodnotenie = Int32.Parse(Console.ReadLine());
                                               
                        if(hodnotenie < 0 || hodnotenie > 100)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        break;
                    }
                    catch(Exception err)
                    {
                        Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", err.Message);
                    }
                    if(hodnotenie >= 0 && hodnotenie <= 100)
                    {
                        break;
                    }
                }
                while(true)
                {
                    try
                    {
                        Console.WriteLine("Chcete hodnotenie aj okomentovat?(ano/nie)");
                        string koment = Console.ReadLine();
                        if(koment.ToLower()=="ano")
                        {
                            Console.WriteLine("Komentar: ");
                            skolenie.Slovny_komentar_hodnotenia[zdenka] = Console.ReadLine();
                            break;
                        }
                        if(koment.ToLower()=="nie")
                        {
                            skolenie.Slovny_komentar_hodnotenia[zdenka] = null;
                            break;
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", e.Message);
                    }
                }
                skolenie.Hodnotenie_studentov[zdenka] = hodnotenie;
            }

            skolenie.Uzavrene = true;
            UlozitSkolenie();
            Console.WriteLine("Skolenie bolo uzavrete!");
        }

        public int ZobrazVyberMenu(string nadpis, string[] polozkyMenu)
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
                catch (Exception chyba)
                {
                    Console.WriteLine("\tDoslo k chybe\n\tdôvod chyby: {0}", chyba.Message);
                }
            }
            return volba;
        }
    }
}
