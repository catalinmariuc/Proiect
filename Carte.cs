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
            nume = "Nume nedefinit";
            autor = "Autor nedefinit";
            editura = "Editura nedefinita";
            pret = 0;
            an_aparitie = DateTime.Now.Year;
        }

        //Constructor cu parametrii:
         public Carte(String nume_param, String autor_param, String editura_param, Int32 pret_param, Int32 an_param)
        {
            nume = nume_param;
            autor = autor_param;
            editura = editura_param;
            pret = pret_param;
            an_aparitie = an_param;
        }

        //Constructor de copiere(nu ar trebui sa fie folosit ):
        public Carte(Carte carte_param)
        {
            nume = carte_param.nume;
            autor = carte_param.autor;
            editura = carte_param.editura;
            pret = carte_param.pret;
            an_aparitie = carte_param.an_aparitie;
        }
    }
}
