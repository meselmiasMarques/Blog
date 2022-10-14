using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;
                            Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        public static void Main(string[] args)
        {

            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            ReadUsers(connection);
            ReadRoles(connection);

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {

            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach (var item in users)
                Console.WriteLine($"{item.Name}");

        }

        public static void ReadRoles(SqlConnection connection)
        {

            var repository = new RoleRepository(connection);
            var roles = repository.Get();

            foreach (var item in roles)
                Console.WriteLine($"{item.Name}");

        }

    }
}