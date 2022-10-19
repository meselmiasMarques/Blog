using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.screens.TagScreen
{
    public class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void List()
        {
            var repository = new Repository<Tag>(DataBase.Connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Slug}");
            }
        }
    }
}