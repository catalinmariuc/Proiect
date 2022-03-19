/*
 * 
 * ACEST FISIER REZOLVA TEMA LABORATORULUI 3
 * 
 */

using Proiect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocareDateFisier
{
    // CLASA PENTRU LUCRUL CU PERSOANE
    public class StocareDateFisierPersoane
    {
        private String numeFisier;
        private const int NR_MAX_PERSOANE = 100;
        public StocareDateFisierPersoane(String numeFisierParam)
        {
            numeFisier = numeFisierParam;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddPersoana(Persoana pers)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(pers.MyToString());
            }
        }
        public Persoana[] GetPersoane(out int nrPersoane)
        {
            Persoana[] persoane = new Persoana[NR_MAX_PERSOANE];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrPersoane = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    persoane[nrPersoane++] = new Persoana(linieFisier);
                }
            }
            return persoane;
        }
    }

    // CLASA PENTRU LUCRUL CU CARTI
    public class StocareDateFisierCarti
    {
        private String numeFisier;
        private const int NR_MAX_CARTI = 100;
        public StocareDateFisierCarti(String numeFisierParam)
        {
            numeFisier = numeFisierParam;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddCarte(Carte carte)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(carte.MyToString());
            }
        }
        public Carte[] GetPersoane(out int nrCarti)
        {
            Carte[] carti = new Carte[NR_MAX_CARTI];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrCarti = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    carti[nrCarti++] = new Carte(linieFisier);
                }
            }
            return carti;
        }
    }
}

