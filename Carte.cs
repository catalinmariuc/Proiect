using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class Carte
    {
        private String nume, autor, editura;
        private Int32 pret, an_aparitie;

        //Constructor implicit:
        public Carte()
        {
            nume = "NUME_NEDEFINIT";
            autor = "AUTOR_NEDEFINIT";
            editura = "EDITURA_NEDEFINITA";
            pret = 0;
            an_aparitie = DateTime.Now.Year;
        }

        //Constructor cu parametrii:
         public Carte(String numeParam, String autorParam, String edituraParam, Int32 pretParam, Int32 anParam)
        {
            nume = numeParam;
            autor = autorParam;
            editura = edituraParam;
            pret = pretParam;
            an_aparitie = anParam;
        }
        //Constructor cu parametru sir de caractere pentru citire din fisier
        public Carte(String carteFisier)
        {
            String[] temp = carteFisier.Split(',');
            nume = temp[0];
            autor = temp[1];
            editura = temp[2];
            pret = Convert.ToInt32(temp[3]);
            an_aparitie = Convert.ToInt32(temp[4]);
        }
        //Constructor de copiere(nu ar trebui sa fie folosit ):
        public Carte(Carte other)
        {
            nume = other.nume;
            autor = other.autor;
            editura = other.editura;
            pret = other.pret;
            an_aparitie = other.an_aparitie;
        }

        public String MyToString()
        {
            return $"{nume},{autor},{editura},{pret},{an_aparitie}";
        }

        static public Carte citireCarteTastatura()
        {
            Console.Write("Nume = ");
            String tempNume = Console.ReadLine().Trim();
            Console.Write("Autor = ");
            String tempAutor = Console.ReadLine().Trim();
            Console.Write("Editura = ");
            String tempEditura = Console.ReadLine().Trim();
            Console.Write("Pret = ");
            int tempPret = Int32.Parse(Console.ReadLine().Trim());
            Console.Write("An aparitie = ");
            int tempAnAparitie = Int32.Parse(Console.ReadLine().Trim());
            Carte cTemp = new Carte(tempNume, tempAutor, tempEditura, tempPret, tempAnAparitie);
            return cTemp;
        }
        static public void afisareCartiFisier(StocareDateFisier.StocareDateFisierCarti stocareCarti, out Int32 nrCarti)
        {
            Carte[] carti = stocareCarti.GetCarti(out nrCarti);
            for (Int32 i = 0; i < nrCarti; i++)
                Console.WriteLine(carti[i].MyToString());
            Console.WriteLine("Apasati o tasta pentru a continua...");
            Console.ReadKey();
        }
        static public Carte gasireCarte(Carte[] carti, Int32 nrCarti, String[] numeSiAutorTemp)
        {
            bool gasit = false;
            for (Int32 i = 0; i < nrCarti; i++)
            {
                String[] carteCurenta = carti[i].MyToString().Split(',');
                if (carteCurenta[0] == numeSiAutorTemp[0] && carteCurenta[1] == numeSiAutorTemp[1])
                {
                    Console.WriteLine($"Carte Gasita!\n{carti[i].MyToString()}");
                    i = nrCarti + 3;
                    gasit = true;
                    Console.WriteLine("Apasati o tasta pentru a continua...");
                    Console.ReadKey();
                    return carti[i];
                }
            }
            if (!gasit)
            {
                Console.WriteLine("Cartea nu a fost gasita!");
            }
            Console.WriteLine("Apasati o tasta pentru a continua...");
            Console.ReadKey();
            return null;
        }
    }
}