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

        //Constructor de copiere(nu ar trebui sa fie folosit ):
        public Carte(Carte other)
        {
            nume = other.nume;
            autor = other.autor;
            editura = other.editura;
            pret = other.pret;
            an_aparitie = other.an_aparitie;
        }
    }
}
