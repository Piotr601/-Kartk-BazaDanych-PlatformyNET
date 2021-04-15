using System;
using System.Data.Entity;

namespace BazaDanych
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine("\n #-------=================================-------#");
            Console.WriteLine(" |                   M E N U                     |");
            Console.WriteLine(" #-------=================================-------#");
            Console.WriteLine(" |    1) Dodaj przykladowe dane                  |");
            Console.WriteLine(" |-----------------------------------------------|");
            Console.WriteLine(" |    2) Dodaj wlasne dane                       |");
            Console.WriteLine(" |-----------------------------------------------|");
            Console.WriteLine(" |    3) Wyswietl baze danych                    |");
            Console.WriteLine(" |-----------------------------------------------|");
            Console.WriteLine(" |    0) # Wyjscie z programu #                  |");
            Console.WriteLine(" #-------=================================-------#\n");
        }

        static void Main(string[] args)
        {

            var wybor = 99;

            menu();

                var baza = new Gra_DB();
            
                var n1 = new Gra() { gatunek = "akcji", nazwa = "Tekken" };
                var n2 = new Gra() { gatunek = "przygodowa", nazwa = "Uncharted" }; 
                var n3 = new Gra() { gatunek = "strategiczna", nazwa = "Warhamer" };

            while (wybor != 0)
            {
                Console.Write("\n >> Wybor: ");

                try
                {
                    wybor = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    // wybierz poprawnie
                }

                // dodaj do bazy danych
                if (wybor == 1)
                {
                    baza.Gry.Add(n1);
                    baza.Gry.Add(n2);
                    baza.Gry.Add(n3);
                    baza.SaveChanges();
                }

                else if (wybor == 2)
                {
                    Console.Write(" Podaj gatunek gry: ");
                    var gat = Console.ReadLine();
                    Console.Write(" Podaj nazwę gry: ");
                    var naz = Console.ReadLine();

                    var n = new Gra() { gatunek = gat, nazwa = naz };

                    baza.Gry.Add(n);
                    baza.SaveChanges();

                }

                // wyswietl cala baze danych
                else if (wybor == 3)
                {
                    Console.WriteLine(" #-------===============####### BAZA #######==============-------#");
                    foreach (var wiersz in baza.Gry)
                    {
                        Console.WriteLine(" >> ID: {0} \t|| Gatunek: {1} \t|| Nazwa: {2} ", wiersz.id, wiersz.gatunek, wiersz.nazwa);
                    }
                }
                else
                {
                    if (wybor != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podaj poprawne dane");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }
            }

        }
    }
}
