using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.screens.TagScreen
{
    public class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualização de tags");
            Console.WriteLine("-------------");

            System.Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Nome: ");
            string name = Console.ReadLine();

            System.Console.WriteLine("Slug: ");
            string slug = Console.ReadLine();

            Update(new Tag()
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        public static void Update(Tag model)
        {
            try
            {
                var repository = new Repository<Tag>(DataBase.Connection);
                repository.Update(model);
                System.Console.WriteLine("Tag Atualizada com Sucesso!");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível Atualizar a tag");
                Console.WriteLine(ex.Message);
            }

        }
    }
}