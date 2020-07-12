namespace Fuel.Api.Helpers
{
    using System;

    public class Helper
    {
        public static string GetConnectionString()
        {
            string dbname = Environment.GetEnvironmentVariable("DB");
            string username = Environment.GetEnvironmentVariable("DB_USER_NAME");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string hostname = Environment.GetEnvironmentVariable("DB_CONNECTION_HOST");
            string port = Environment.GetEnvironmentVariable("DB_PORT");

            return $"Username={username};Password={password};Host={hostname};Port={port};Database={dbname};Integrated Security=true;Pooling=true";
        }
    }
}
