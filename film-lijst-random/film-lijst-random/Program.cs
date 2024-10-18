using System;
using System.Collections.Generic;
using System.Linq;


namespace film_lijst_random
{
    internal class Program
    {
        private const string ConnectionString = "Server=localhost;Database=sakila;user=root;";
        static void Main(string[] args)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConnectionString);
            List<Tuple<string, string, string, string>> films = dbHelper.GetFilm();

            while (true)
            {
                // Print alle films in de database
                foreach (var film in films)
                {
                    Console.WriteLine($"Film ID: {film.Item1}");
                    Console.WriteLine($"Title: {film.Item2}");
                    Console.WriteLine($"Description: {film.Item3}");
                    Console.WriteLine($"Rating: {film.Item4}");
                    Console.WriteLine();
                }

                // geef de gebruiker meerdere opties 
                Console.WriteLine("Wil je een film zoeken, een film verwijderen, of het programma afsluiten? (zoek/verwijder/exit)");
                Console.WriteLine("Als je een film wilt verwijderen, geef dan het film ID op. Als je een film wilt zoeken, geef dan de zoekterm op.");
                string input = Console.ReadLine().ToLower();

                if (input == "exit")
                {
                    break;
                }

                if (input == "zoek")
                {
                    Console.WriteLine("Geef een zoekterm op:");
                }
                else if (input == "verwijder")
                {
                    Console.WriteLine("Geef het film ID op van de film die je wilt verwijderen:");
                }
                else
                {
                    Console.WriteLine("Ongeldige invoer.");
                    continue;
                }

                string search = Console.ReadLine().ToUpper();

                if (input == "zoek")
                {
                    Console.WriteLine("Zoekresultaten:");
                    List<Tuple<string, string, string, string>> searchFilms = films.Where(film => film.Item2.Contains(search)).ToList();
                    foreach (var film in searchFilms)
                    {
                        Console.WriteLine($"Film ID: {film.Item1}");
                        Console.WriteLine($"Title: {film.Item2}");
                        Console.WriteLine($"Description: {film.Item3}");
                        Console.WriteLine($"Rating: {film.Item4}");
                        Console.WriteLine();
                    }
                }
                else if (input == "verwijder")
                {
                    dbHelper.DeleteFilm(search);
                    Console.WriteLine("Film verwijderd:");

                    //refresh de lijst zodat de verwijderde film niet meer in de lijst staat
                    films = dbHelper.GetFilm();
                }
            }
        }
    }
}
