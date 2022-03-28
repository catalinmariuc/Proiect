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
            //StocareDateFisier.StocareDateFisierCarti adminCarti = new StocareDateFisier.StocareDateFisierCarti(ConfigurationManager.AppSettings.Get("numeFisierCarti"));
            StocareDateFisier.StocareDateFisierPersoane adminPersoane;
            //LAB 4(EX1)
            if (args.Length != 0)
                adminPersoane = new StocareDateFisier.StocareDateFisierPersoane(args[1]);
            else
                adminPersoane = new StocareDateFisier.StocareDateFisierPersoane(ConfigurationManager.AppSettings.Get("numeFisierPersoane"));
            Int32 nrPersoane = 0;

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
                        persoanaTastatura = Persoana.citirePersoanaTastatura();
                        break;
                    case 'S':
                        //SALVAREA DATELOR INTRODUSE DE LA TASTATURA IN FISIER(LAB 3)
                        adminPersoane.AddPersoana(persoanaTastatura);
                        break;
                    case 'A':
                        //AFISAREA DATELOR DIN FISIER PE CONSOLA(LAB 3)
                        Persoana.afisarePersoaneFisier(adminPersoane, out nrPersoane);
                        break;
                    case 'F':
                        //GASIREA UNEI PERSOANE DUPA NUME SI PRENUME
                        Console.WriteLine("Introduceti numele si prenumele persoanei cautate:");
                        String[] numeSiPrenumeTemp = Console.ReadLine().Trim().Split();
                        Persoana.gasirePersoana(adminPersoane.GetPersoane(out nrPersoane), nrPersoane, numeSiPrenumeTemp);
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
