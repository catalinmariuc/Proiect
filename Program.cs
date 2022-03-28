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
            Carte carteTastatura = null;
            StocareDateFisier.StocareDateFisierCarti adminCarti = new StocareDateFisier.StocareDateFisierCarti(ConfigurationManager.AppSettings.Get("numeFisierCarti"));
            StocareDateFisier.StocareDateFisierPersoane adminPersoane;
            //LAB 4(EX1)
            if (args.Length != 0)
                adminPersoane = new StocareDateFisier.StocareDateFisierPersoane(args[1]);
            else
                adminPersoane = new StocareDateFisier.StocareDateFisierPersoane(ConfigurationManager.AppSettings.Get("numeFisierPersoane"));
            Int32 nrPersoane = 0;
            Int32 nrCarti = 0;

            //CONFIG
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(90, 35);

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
                        Console.WriteLine("Pentru a introduce o carte apasati C, pentru a introduce o persoana apasati P");
                        opt = Meniu.Meniu.alegeOptiune();
                        switch(opt)
                        {
                            case 'P':
                                persoanaTastatura = Persoana.citirePersoanaTastatura();
                                break;
                            case 'C':
                                carteTastatura = Carte.citireCarteTastatura();
                                break;
                            default:
                                Console.WriteLine("Ati introdus o tasta gresita... Apasati o tasta...");
                                Console.ReadKey();
                                break;
                        }
                        

                        break;
                    case 'S':
                        //SALVAREA DATELOR INTRODUSE DE LA TASTATURA IN FISIER(LAB 3)
                        Console.WriteLine("Pentru a introduce o carte apasati C, pentru a introduce o persoana apasati P");
                        opt = Meniu.Meniu.alegeOptiune();
                        switch (opt)
                        {
                            case 'P':
                                adminPersoane.AddPersoana(persoanaTastatura);
                                break;
                            case 'C':
                                adminCarti.AddCarte(carteTastatura);
                                break;
                            default:
                                Console.WriteLine("Ati introdus o tasta gresita... Apasati o tasta...");
                                Console.ReadKey();
                                break;
                        }
                        
                        break;
                    case 'A':
                        //AFISAREA DATELOR DIN FISIER PE CONSOLA(LAB 3)
                        Console.WriteLine("Pentru a afisa cartile apasati C, pentru a afisa persoanele apasati P");
                        opt = Meniu.Meniu.alegeOptiune();
                        switch (opt)
                        {
                            case 'P':
                                Persoana.afisarePersoaneFisier(adminPersoane, out nrPersoane);
                                break;
                            case 'C':
                                Carte.afisareCartiFisier(adminCarti, out nrCarti);
                                break;
                            default:
                                Console.WriteLine("Ati introdus o tasta gresita... Apasati o tasta...");
                                Console.ReadKey();
                                break;
                        }
                        
                        break;
                    case 'F':
                        //GASIREA UNEI PERSOANE DUPA NUME SI PRENUME
                        Console.WriteLine("Pentru a afisa cartile apasati C, pentru a afisa persoanele apasati P");
                        opt = Meniu.Meniu.alegeOptiune();
                        switch (opt)
                        {
                            case 'P':
                                Console.WriteLine("Introduceti numele si prenumele persoanei cautate:");
                                String[] numeSiPrenumeTemp = Console.ReadLine().Trim().Split();
                                Persoana.gasirePersoana(adminPersoane.GetPersoane(out nrPersoane), nrPersoane, numeSiPrenumeTemp);
                                break;
                            case 'C':
                                Console.WriteLine("Introduceti numele cartii si autorul cautat:");
                                String[] numeSiAutorTemp = Console.ReadLine().Trim().Split(',');
                                Carte.gasireCarte(adminCarti.GetCarti(out nrCarti), nrCarti, numeSiAutorTemp);
                                break;
                            default:
                                Console.WriteLine("Ati introdus o tasta gresita... Apasati o tasta...");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case 'X':
                        //EXIT(LAB 3)
                        Meniu.Meniu.superSecretExitRoutine();
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
