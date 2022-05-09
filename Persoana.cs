using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class Persoana
    {
        public String nume { get; set; }
        public String prenume { get; set; }
        public String email { get; set; }
        public String nrTel { get; set; }
        public DateTime dob { get; set; } //Date of birth
        //private Int32 id;

        public Persoana()
        {
            nume = "NUME_DEFAULT";
            prenume = "PRENUME_DEFAULT";
            nrTel = "0000000000";
            email = "DEFAULT_EMAIL@DEFAULT.COM";
            dob = new DateTime(2000, 1, 1);
        }

        public Persoana(String numeParam, String prenumeParam, String emailParam, String nrTelParam, DateTime dobParam)
        {
            nume = numeParam;
            prenume = prenumeParam;
            email = emailParam;
            nrTel = nrTelParam;
            dob = dobParam;

        }

        public Persoana(String liniefisier)
        {
            String[] temp = liniefisier.Split(',');
            nume = temp[0];
            prenume = temp[1];
            email = temp[2];
            nrTel = temp[3];
            int[] tempDATA = Array.ConvertAll(temp[4].Trim().Split('/'), s => int.Parse(s));
            dob = new DateTime(tempDATA[2], tempDATA[1], tempDATA[0]);
        }
        public Persoana(Persoana other)
        {
            nume = other.nume;
            prenume = other.prenume;
            email = other.email;
            nrTel = other.nrTel;
            dob = other.dob;
        }

        public String MyToString()
        {
            return $"{nume},{prenume},{email},{nrTel},{(dob.ToString().Split())[0]}";
        }

        static public Persoana citirePersoanaTastatura()
        {
            Console.Write("Nume = ");
            String tempNume = Console.ReadLine().Trim();
            Console.Write("Prenume = ");
            String tempPrenume = Console.ReadLine().Trim();
            Console.Write("Email = ");
            String tempEmail = Console.ReadLine().Trim();
            Console.Write("Nr. Telefon = ");
            String tempNrTel = Console.ReadLine().Trim();
            Console.Write("Data nasterii (DD/MM/YYYY) = ");
            int[] tempDATA = Array.ConvertAll(Console.ReadLine().Trim().Split('/'), s => int.Parse(s));//converteste din string in int tot vectorul, pe viitor voi face un constructor separat
            DateTime tempDob = new DateTime(tempDATA[2], tempDATA[1], tempDATA[0]);
            Persoana pTemp = new Persoana(tempNume, tempPrenume, tempEmail, tempNrTel, tempDob);
            return pTemp;
        }
        static public void afisarePersoaneFisier(StocareDateFisier.StocareDateFisierPersoane stocarePersoane, out Int32 nrPersoane)
        {
            Persoana[] persoane = stocarePersoane.GetPersoane(out nrPersoane);
            for (Int32 i = 0; i < nrPersoane; i++)
                Console.WriteLine(persoane[i].MyToString());
            Console.WriteLine("Apasati o tasta pentru a continua...");
            Console.ReadKey();
        }
        static public Persoana gasirePersoana(Persoana[] persoane, Int32 nrPersoane, String[] numeSiPrenumeTemp)
        {
            bool gasit = false;
            for (Int32 i = 0; i < nrPersoane; i++)
            {
                String[] persCurenta = persoane[i].MyToString().Split(',');
                if (persCurenta[0] == numeSiPrenumeTemp[0] && persCurenta[1] == numeSiPrenumeTemp[1])
                {
                    Console.WriteLine($"Persoana Gasita!\n{persoane[i].MyToString()}");
                    gasit = true;
                    Console.WriteLine("Apasati o tasta pentru a continua...");
                    //Console.ReadKey();
                    return persoane[i];
                }
            }
            if (!gasit)
            {
                Console.WriteLine("Persoana nu a fost gasita!");
            }
            Console.WriteLine("Apasati o tasta pentru a continua...");
            //Console.ReadKey();
            return null;
        }
    }
}
