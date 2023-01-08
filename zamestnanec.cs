using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprava_skoleni
{
    public class Zamestnanec
    {
        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public string Kod { get; set; }
        public string Nazov_pozicie { get; set; }
    }

    public class Student : Zamestnanec
    {
        public List<Skoleni> Skolenie { get; set; }

        public Student(string meno, string priezvisko, string kod, string nazov_pozicie)
        {
            Meno = meno;
            Priezvisko = priezvisko;
            Kod = kod;
            Nazov_pozicie = nazov_pozicie;
            Skolenie = new List<Skoleni>();
        }
    }

    public class Lektor : Zamestnanec
    {
        public List<Skoleni> VyucovanaSkoleni { get; set; }

        public Lektor(string meno, string priezvisko, string kod, string nazov_pozicie)
        {
            Meno = meno;
            Priezvisko = priezvisko;
            Kod = kod;
            Nazov_pozicie = nazov_pozicie;
            VyucovanaSkoleni = new List<Skoleni>();
        }
    }

    public class Skoleni
    {
        public string Nazov { get; set; }
        public string Popis { get; set; }
        public DateTime PociatocneDatum { get; set; }
        public DateTime KoncoveDatum { get; set; }
        public List<Student> Studenti { get; set; }
        public List<Lektor> Lektori { get; set; }
        public Dictionary<Student, int> Hodnotenie_studentov { get; set; }
        public Dictionary<Student, string> Slovny_komentar_hodnotenia { get; set; }
        public int DoporucenyPocetUcastniku { get; set; }
        public bool Uzavrene { get; set; }

        public Skoleni(string nazov, string popis, DateTime pociatocne_datum, DateTime koncove_datum, 
            List<Student> studenti, List<Lektor> lektori, Dictionary<Student, int> hodnotenie_studentov, 
            Dictionary<Student, string> slovny_komentar_hodnotenia, int doporucenyPocetUcastnikov, bool uzavrene)
        {
            Nazov = nazov;
            Popis = popis;
            PociatocneDatum = pociatocne_datum;
            KoncoveDatum = koncove_datum;
            Studenti = studenti;
            Lektori = lektori;
            Hodnotenie_studentov = hodnotenie_studentov;
            Slovny_komentar_hodnotenia = slovny_komentar_hodnotenia;
            DoporucenyPocetUcastniku = doporucenyPocetUcastnikov;
            Uzavrene = uzavrene;
        }
    }
}
