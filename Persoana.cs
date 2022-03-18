using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class Persoana
    {
        private String nume, prenume, email, nrTel;
        private DateTime dob; //Date of birth

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
            return nume + ' ' + prenume + ' ' + email + ' ' + nrTel + ' ' + (dob.ToString().Split())[0];
        }
    }
}
