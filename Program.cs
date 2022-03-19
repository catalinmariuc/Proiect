using System;
using Meniu;

namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            //Carte carte_test;
            Persoana persoanaTastatura;
            //Console.WriteLine(carte_test); - inca nu pot face asta, urmeazaa
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(90, 20);
            while(true)
            {
                Console.Clear();
                Meniu.Meniu.printMeniu();
                char opt = Meniu.Meniu.alegeOptiune();
                switch(opt)
                {
                    case 'C':
                        Console.Write("Nume = ");
                        String tempNume = Console.ReadLine().Trim();
                        Console.Write("Prenume = ");
                        String tempPrenume = Console.ReadLine().Trim();
                        Console.Write("Email = ");
                        String tempEmail = Console.ReadLine().Trim();
                        Console.Write("Nr. Telefon = ");
                        String tempNrTel = Console.ReadLine().Trim();
                        Console.Write("Data nasterii (DD/MM/YYYY) = ");
                        int[] tempDATA = Array.ConvertAll(Console.ReadLine().Trim().Split('/'), s => int.Parse(s));
                        DateTime tempDob = new DateTime(tempDATA[2], tempDATA[1], tempDATA[0]);
                        persoanaTastatura = new Persoana(tempNume, tempPrenume, tempEmail, tempNrTel, tempDob);
                        break;
                    case 'S':
                        //de completat
                        break;
                    case 'A':
                        //de completat
                        break;
                    case 'X':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nu exista optiunea aleasa!");
                        break;
                }
            }
        }
    }
}
