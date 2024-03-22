using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;


public class DatabaseHelper
{
    // Stores the connection string for the database. This is a key detail that allows
    // the class to establish a connection to the database.
    private readonly string _connectionString;

    // Constructor that takes a database connection string. This connection string is 
    // essential for opening a connection to the database.
    public DatabaseHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Asynchronously fetches data from the database. This generic method is flexible and can return any type of data.
    // T: The type of objects that this method will return in a list.
    // query: The SQL query to be executed.
    // parameters: A dictionary of parameters to be used in the query, preventing SQL injection.
    // transform: A function that converts each row from the result set into an instance of type T.
    public async Task<List<T>> GetDataAsync<T>(string query, Dictionary<string, object> parameters, Func<DbDataReader, T> transform)
    {
        var items = new List<T>();
        using (var connection = new MySqlConnection(_connectionString)) // Establishes a new database connection.
        {
            await connection.OpenAsync(); // Asynchronously opens the connection.
            using (var command = new MySqlCommand(query, connection)) // Creates a command to execute the query.
            {
                if (parameters != null) // Checks if there are any parameters to add to the command.
                {
                    foreach (var param in parameters) // Iterates through each parameter and adds it to the command.
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                using (var reader = await command.ExecuteReaderAsync()) // Executes the command and gets a data reader.
                {
                    while (await reader.ReadAsync()) // Reads each row in the result set.
                    {
                        items.Add(transform(reader)); // Transforms each row into an object of type T and adds it to the list.
                    }
                }
            }
        }
        return items;  // Returns the list of transformed objects.
    }

    // Executes a query that returns a single value. Useful for queries that use aggregate functions like COUNT, MAX, etc.
    public async Task<object> ExecuteScalarAsync(string query, Dictionary<string, object> parameters)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var command = new MySqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                return await command.ExecuteScalarAsync();
            }
        }
    }

    // Executes a command that modifies the database (e.g., INSERT, UPDATE, DELETE) and returns the number of affected rows.
    public async Task<int> ExecuteAsync(string query, Dictionary<string, object> parameters)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var command = new MySqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}