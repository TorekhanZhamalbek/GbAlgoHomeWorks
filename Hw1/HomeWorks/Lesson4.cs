using System;
using HomeWorksInterface;

namespace HomeWorks
{
    public class Lesson4 : ILesson
    {
        public string Name => "4";

        public string Description => "Домашнее задание 4";

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
            Console.WriteLine(new string('-', 40));
            binaryTree.DeleteNote(binaryTree.FindNoteByValue(3));
            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            binaryTree.DeleteNote(binaryTree.FindNoteByValue(8));
            binaryTree.PrintTree();
        }
    }
}
