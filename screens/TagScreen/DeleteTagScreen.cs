using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.screens.TagScreen
{
    public class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Exclusão de tags");
            Console.WriteLine("-------------");

            System.Console.WriteLine("Digite o Id para Excluir: ");
            int id = int.Parse(Console.ReadLine());

            Delete(id);
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(DataBase.Connection);
                repository.Delete(id);
                System.Console.WriteLine("Tag Excluída com Sucesso!");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível Excluir a tag");
                Console.WriteLine(ex.Message);
            }

        }
    }
}