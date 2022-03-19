using System;
using System.Configuration;
using Meniu;

namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            //DECLARATII DATE
            Persoana persoanaTastatura = null;
            StocareDateFisier.StocareDateFisierCarti adminCarti = new StocareDateFisier.StocareDateFisierCarti(ConfigurationManager.AppSettings.Get("numeFisierCarti"));
            StocareDateFisier.StocareDateFisierPersoane adminPersoane = new StocareDateFisier.StocareDateFisierPersoane(ConfigurationManager.AppSettings.Get("numeFisierPersoane"));
            Int32 nrPersoane = 0;
            Persoana[] persoane = adminPersoane.GetPersoane(out nrPersoane);

            //CONFIG
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(90, 20);

            //INFINITE LOOP
            while(true)
            {
                //AFISARE MENIU, SELECTARE OPTIUNE
                Console.Clear();
                Meniu.Meniu.printMeniu();
                char opt = Meniu.Meniu.alegeOptiune();
                Console.Clear();
                switch (opt)
                {
                    case 'C':
                        //CITIREA DATELOR DE LA TASTATURA(LAB 3)
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
                        persoanaTastatura = new Persoana(tempNume, tempPrenume, tempEmail, tempNrTel, tempDob);
                        break;
                    case 'S':
                        //SALVAREA DATELOR INTRODUSE DE LA TASTATURA IN FISIER(LAB 3)
                        adminPersoane.AddPersoana(persoanaTastatura);
                        break;
                    case 'A':
                        //AFISAREA DATELOR DIN FISIER PE CONSOLA(LAB 3)
                        persoane = adminPersoane.GetPersoane(out nrPersoane);
                        for(Int32 i=0; i<nrPersoane; i++)
                            Console.WriteLine(persoane[i].MyToString());
                        Console.WriteLine("Apasati o tasta pentru a continua...");
                        Console.ReadKey();
                        break;
                    case 'F':
                        //GASIREA UNEI PERSOANE DUPA NUME SI PRENUME
                        Console.WriteLine("Introduceti numele si prenumele persoanei cautate:");
                        String[] numeSiPrenumeTemp = Console.ReadLine().Trim().Split();
                        bool gasit = false;
                        for(Int32 i=0; i<nrPersoane; i++)
                        {
                            String[] persCurenta = persoane[i].MyToString().Split(',');
                            if (persCurenta[0] == numeSiPrenumeTemp[0] && persCurenta[1] == numeSiPrenumeTemp[1])
                            {
                                Console.WriteLine($"Persoana Gasita!\n{persoane[i].MyToString()}");
                                i = nrPersoane+3;
                                gasit = true;
                            }
                        }
                        if (!gasit)
                            Console.WriteLine("Persoana nu a fost gasita!");
                        Console.WriteLine("Apasati o tasta pentru a continua...");
                        Console.ReadKey();
                        break;
                    case 'X':
                        //EXIT(LAB 3)
                        Environment.Exit(0);
                        break;
                    default:
                        //IN CAZ DE ORICE
                        Console.WriteLine("Nu exista optiunea aleasa!");
                        break;
                }
            }
        }
    }
}
