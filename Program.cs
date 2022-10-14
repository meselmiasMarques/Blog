using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    public class Program
    {
        //mac docker
        private const string CONNECTION_STRING = @"Server=localhost,1433;
                                    Database=Blog;User ID=sa;Password=caroline@0701;TrustServerCertificate=True;MultiSubnetFailover=True;";


        //Windows
        // private const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;
        //                     Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;
        //                     Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
        //                     MultiSubnetFailover=False";

        public static void Main(string[] args)
        {

            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            ReadUsersWithRoles(connection);
            //ReadUsers(connection);
            //ReadRoles(connection);
            //ReadTags(connection);

            //CreateUser(connection);
            // CreateRoles(connection);
            // CreateTags(connection);

            //UpdateUsers(connection);
            // UpdateRoles(connection);
            // UpdateTags(connection);


            //DeleteUsers(connection);
            //DeleteRoles(connection);
            //DeleteTags(connection);



            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($"{role.Name}");
                }
            }
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($"{role.Name}");
                }
            }
        }
        public static void ReadRoles(SqlConnection connection)
        {

            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine($"{item.Name}");

        }

        public static void ReadTags(SqlConnection connection)
        {

            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            // var user = new User
            // {
            //     Name = "Miguel",
            //     Email = "miguel@balta.io",
            //     PasswordHash = "HASH",
            //     Bio = "miguel-balta",
            //     Image = "https/...",
            //     Slug = "MiguelBalta"
            // };

            // var repository = new Repository<User>(connection);
            // repository.Create(user);

            // Console.WriteLine("Cadastro Realizado com Sucesso");
        }

        public static void CreateRoles(SqlConnection connection)
        {
            var role = new Role
            {
                Name = "André",
                Slug = "escritor"
            };

            var repository = new Repository<Role>(connection);
            repository.Create(role);
            Console.WriteLine("Cadastro Realizado com Sucesso");
        }

        public static void CreateTags(SqlConnection connection)
        {
            var tag = new Tag
            {
                Name = "Blazor",
                Slug = "blazor"
            };

            var repository = new Repository<Tag>(connection);
            repository.Create(tag);
            Console.WriteLine("Cadastro Realizado com Sucesso");
        }


        public static void UpdateUsers(SqlConnection connection)
        {
            // var user = new User
            // {
            //     Id = 5,
            //     Name = "Miguel Marques",
            //     Email = "miguel@balta.io",
            //     PasswordHash = "HASH",
            //     Bio = "miguel-balta",
            //     Image = "https/...",
            //     Slug = "MiguelBalta"
            // };

            //     var repository = new Repository<User>(connection);
            //     repository.Update(user);
            //     Console.WriteLine("Atualização realizada com Sucesso!");
            // 
        }

        public static void UpdateRoles(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 1,
                Name = "André",
                Slug = "escritor"
            };

            var repository = new Repository<Role>(connection);
            repository.Update(role);
            Console.WriteLine("Atualização realizada com Sucesso!");
        }

        public static void UpdateTags(SqlConnection connection)
        {
            var tag = new Tag
            {
                Id = 1,
                Name = "Blazor",
                Slug = "blazor"
            };

            var repository = new Repository<Tag>(connection);
            repository.Update(tag);
            Console.WriteLine("Atualização realizada com Sucesso!");
        }


        public static void DeleteUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);

            //recupera o id para exclusão.
            var id = repository.Get(5);
            repository.Delete(id);
            System.Console.WriteLine("Excluído com Sucesso");
        }

        public static void DeleteRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);

            //recupera o id para exclusão.
            var id = repository.Get(1);
            repository.Delete(id);
            System.Console.WriteLine("Excluído com Sucesso");
        }

        public static void DeleteTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);

            //recupera o id para exclusão.
            var id = repository.Get(1);
            repository.Delete(id);
            System.Console.WriteLine("Excluído com Sucesso");
        }

    }
}