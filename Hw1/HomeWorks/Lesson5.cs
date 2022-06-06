using System;
using HomeWorksInterface;

namespace HomeWorks
{
    public class Lesson5 : ILesson
    {
        public string Name => "5";

        public string Description => "Домашнее задание 5";

        public void Run()
        {
            Console.WriteLine($"---{Description}---");
            var binaryTree = new BinaryTree();
            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.PrintTree();
            var findByBFS = binaryTree.BFS(1);
            Console.WriteLine("Найденное значение по BFS = " + findByBFS.Value);
            var findByDFS = binaryTree.DFS(1);
            Console.WriteLine("Найденное значение по DFS = " + findByDFS.Value);
        }
    }
}
