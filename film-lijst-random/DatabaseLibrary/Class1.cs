﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class DataBaseHelper
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
                    // Add the film to the list of films with the title, description and rating of the film
                    FilmLijst.Add(new Tuple<string, string, string, string>(reader["film_id"].ToString(), reader["title"].ToString(), reader["description"].ToString(), reader["rating"].ToString()));
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
    // maak een functie om een film te verwijderen uit de database
    public void DeleteFilm(string filmId)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            string query = $"DELETE FROM `film` WHERE film_id = {filmId}";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
