using System;
using Microsoft.Data.Sqlite;
using LunchApp1.Models;

namespace LunchApp1.Data
{
    public class DatabaseHandler
    {
        // ✅ Ändring av connection string här (Version=3; är borttagen)
        private readonly string connectionString = "Data Source=lunchapp.db;";

        public void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Restaurants (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Cuisine TEXT NOT NULL,
                        Distance INTEGER NOT NULL,
                        PriceRange TEXT NOT NULL
                    );";

                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Table created or already exists.");
            }
        }

        public void InsertRestaurants()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO Restaurants (Name, Cuisine, Distance, PriceRange) VALUES 
                    ('Marrakesh', 'Moroccan Buffet', 100, '100-200kr'),
                    ('Parked Salad Bar', 'Salad', 100, '100-200kr'),
                    ('Smeden Mathall', 'Foodcourt', 100, '100-200kr'),
                    ('Klå Fann Thai', 'Thai', 350, '100-200kr'),
                    ('Babas', 'Burgers', 200, '100-200kr'),
                    ('Pocket in the Park', 'Husman/Bistro', 200, '100-200kr'),
                    ('Le Kebab', 'Kebab', 300, '100-200kr'),
                    ('Itamae', 'Sushi', 300, '100-200kr'),
                    ('Café Volta', 'Modern European', 200, '100-200kr');";

                using (var command = new SqliteCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Restaurants have been inserted into the database.");
            }
        }

        public void DisplayRestaurants()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Restaurants";

                using (var command = new SqliteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}: {reader["Name"]} - {reader["Cuisine"]} ({reader["Distance"]} m) - Price: {reader["PriceRange"]}");
                    }
                }
            }
        }
    }
}
