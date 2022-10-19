using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.screens.TagScreen
{
    public class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de tags");
            Console.WriteLine("-------------");
            System.Console.WriteLine("Nome: ");
            string name = Console.ReadLine();

            System.Console.WriteLine("Slug: ");
            string slug = Console.ReadLine();

            Create(new Tag()
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        public static void Create(Tag model)
        {
            try
            {
                var repository = new Repository<Tag>(DataBase.Connection);
                repository.Create(model);
                System.Console.WriteLine("Tag Cadastrada com Sucesso!");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a tag");
                Console.WriteLine(ex.Message);
            }

        }
    }

}