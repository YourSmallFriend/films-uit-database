using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using film_lijst_random;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace film_lijst_random
{
    internal class Program
    {
        private const string ConnectionString = "Server=localhost;Database=sakila;user=root;";
        static void Main(string[] args)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConnectionString);
            List<Tuple<string, string, string, string>> films = dbHelper.GetFilm();


            //maak een search string
            Console.WriteLine("Geef een zoekterm op:");
            string search = Console.ReadLine().ToUpper();

            //zoek naar films die de zoekterm bevatten
            List<Tuple<string, string, string, string>> searchFilms = films.Where(film => film.Item2.Contains(search)).ToList();

            //print alle films die de zoekterm bevatten
            foreach (var film in searchFilms)
            {
                Console.WriteLine($"Film ID: {film.Item1}");
                Console.WriteLine($"Title: {film.Item2}");
                Console.WriteLine($"Description: {film.Item3}");
                Console.WriteLine($"Rating: {film.Item4}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}
