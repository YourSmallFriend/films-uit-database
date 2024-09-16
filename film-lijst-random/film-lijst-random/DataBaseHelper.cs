using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class DataBaseHelper
{
    private string ConnectionString { get; }

    public DataBaseHelper(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public List<Tuple<string, string, string, string>> GetFilm()
    {
        var FilmLijst = new List<Tuple<string, string, string, string>>();

        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            string query = "SELECT film_id, title, description, rating FROM `film`";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["film_id"].ToString();
                    var title = reader["title"].ToString();
                    var description = reader["description"].ToString();
                    var rating = reader["rating"].ToString();
                    FilmLijst.Add(Tuple.Create(id, title, description, rating));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        return FilmLijst;
    }
}
