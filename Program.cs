﻿using Microsoft.Data.Sqlite;
namespace Lab03_Sqlite;
class Program
{
    static void Main(string[] args)
    {
        int id = 2;
        Console.WriteLine("Hello, World!");
        using (var connection = new SqliteConnection("Data Source=hello.db"))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
        SELECT name
        FROM user
        WHERE id = $id
    ";
            command.Parameters.AddWithValue("$id", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);

                    Console.WriteLine($"Hello, {name}!");
                }
            }
        }
    }
}
