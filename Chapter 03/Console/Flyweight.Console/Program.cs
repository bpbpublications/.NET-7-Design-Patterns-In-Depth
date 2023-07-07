using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Tree> trees = new();
            TreeType type = new TreeFactory()["pine", "green", "short"];
            Tree tree1 = new(type, 1, 1);
            trees.Add(tree1);
            Tree tree2 = new(type, 2, 2);
            trees.Add(tree2);
            Tree tree3 = new(type, 3, 3);
            trees.Add(tree3);

            foreach (var item in trees)
            {
                item.Draw(item);
            }
            Console.Read();
        }
    }
}
