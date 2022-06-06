using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class LinkedList : ILinkedList
    {
        private Node head = new Node();
        private Node tail = new Node();

        public LinkedList()
        {
            head.NextNode = tail;
            tail.PrevNode = head;
        }
        public int GetCount()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                current = current.NextNode;
                count++;
            }
            return count;
        }

        public void AddNode(int value)
        {
            var node = head;

            while (node.NextNode != null)
            {
                node = node.NextNode;
            }

            var newNode = new Node()
            {
                Value = value,
                PrevNode = node
            };

            node.NextNode = newNode;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node
            {
                Value = value,
                NextNode = node.NextNode,
                PrevNode = node
            };
            node.NextNode = newNode;
        }

        public void RemoveNode(int index)
        {
            int count = 0;
            Node current = head;
            while (current != null && count < index)
            {
                current = current.NextNode;
                count++;
            }
            if (count == index)
            {
                RemoveNode(current);
            }
            else
            {
                Console.WriteLine($"Узел с индексом - {index} не существует!");
            }
        }

        public void RemoveNode(Node node)
        {
            var prev = node.PrevNode;
            var next = node.NextNode;

            if (next != null)
            {
                next.PrevNode = prev;
            }
            prev.NextNode = next;
        }
        public Node FindNode(int searchValue)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Value == searchValue)
                {
                    return current;
                }
                current = current.NextNode;
            }

            return null;
        }
    }
}
