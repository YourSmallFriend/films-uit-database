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

            // 3 random films instead of all the films
            Random random = new Random();
            films = films.OrderBy(x => random.Next()).Take(3).ToList();

            foreach (var film in films)
            {
                // Print each film to the console
                Console.WriteLine($"film_id: {film.Item1}\nTitle: {film.Item2}\nDescription: {film.Item3}\nRating: {film.Item4}\n");
            }
            Console.ReadLine();
        }
    }
}
