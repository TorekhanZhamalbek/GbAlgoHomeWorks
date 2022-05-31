using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    class BinaryTree
    {
        public TreeNode Root { get; set; }

        public TreeNode Add(int value, TreeNode currentNode = null)
        {
            if (Root == null)
            {
                Root = GetFreeNode(value, null);
                return Root;
            }

            currentNode = currentNode ?? Root;

            while (currentNode != null)
            {
                if (value > currentNode.Value)
                {
                    if (currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                        continue;
                    }
                    else
                    {
                        currentNode.RightChild = GetFreeNode(value, currentNode);
                        return currentNode.RightChild;
                    }
                }
                else if (value < currentNode.Value)
                {
                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                        continue;
                    }
                    else
                    {
                        currentNode.LeftChild = GetFreeNode(value, currentNode);
                        return currentNode.LeftChild;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state"); //
                }
            }
            return Root;
        }
        public TreeNode Add(TreeNode node, TreeNode currentNode = null)
        {
            if (Root == null)
            {
                node.ParentNode = null;
                return Root = node;
            }

            currentNode = currentNode ?? Root;
            node.ParentNode = currentNode;



            int result = node.Value - currentNode.Value;
            if (result == 0)
            {
                return currentNode;
            }
            else if (result < 0)
            {
                if (currentNode.LeftChild == null)
                {
                    return currentNode.LeftChild = node;
                }
                else
                {
                    return Add(node, currentNode.LeftChild);
                }
            }
            else
            {
                if (currentNode.RightChild == null)
                {
                    return currentNode.RightChild = node;
                }
                else
                {
                    return Add(node, currentNode.RightChild);
                }
            }
        }
        public TreeNode GetFreeNode (int value, TreeNode tmp)
        {
            TreeNode node = new TreeNode();
            node.Value = value;
            node.ParentNode = tmp;

            return node;
        }
        public TreeNode FindNoteByValue(int value)
        {
            TreeNode currentNode = Root;

            while (value != currentNode.Value)
            {
                if (value > currentNode.Value)
                {
                    if (currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                        continue;
                    }
                }
                else if (value < currentNode.Value)
                {
                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                        continue;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");
                }
            }

            return currentNode;
        }

        public void DeleteNote(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            //если у узла нет подузлов, можно его удалить
            if (node.LeftChild == null && node.RightChild == null)
            {
                if (node == node.ParentNode.LeftChild)
                {
                    node.ParentNode.LeftChild = null;
                }
                else
                {
                    node.ParentNode.RightChild = null;
                }
            }
            //если нет левого, то правый ставим на место удаляемого 
            else if (node.LeftChild == null)
            {
                if (node == node.ParentNode.LeftChild)
                {
                    node.ParentNode.LeftChild = node.RightChild;
                }
                else
                {
                    node.ParentNode.RightChild = node.RightChild;
                }

                node.RightChild.ParentNode = node.ParentNode;
            }
            //если нет правого, то левый ставим на место удаляемого 
            else if (node.RightChild == null)
            {
                if (node == node.ParentNode.LeftChild)
                {
                    node.ParentNode.LeftChild = node.LeftChild;
                }
                else
                {
                    node.ParentNode.RightChild = node.LeftChild;
                }

                node.LeftChild.ParentNode = node.ParentNode;
            }
            //если оба дочерних присутствуют, 
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else
            {
                if (node.ParentNode != null)
                {
                    if (node == node.ParentNode.LeftChild)
                    {
                        node.ParentNode.LeftChild = node.RightChild;
                        node.RightChild.ParentNode = node.ParentNode;
                        Add(node.LeftChild, node.RightChild);
                    }
                    else if (node == node.ParentNode.RightChild)
                    {
                        node.ParentNode.RightChild = node.RightChild;
                        node.RightChild.ParentNode = node.ParentNode;
                        Add(node.LeftChild, node.RightChild);
                    }
                }
                else
                {
                    var bufLeft = node.LeftChild;
                    var bufRightLeft = node.RightChild.LeftChild;
                    var bufRightRight = node.RightChild.RightChild;
                    node.Value = node.RightChild.Value;
                    node.RightChild = bufRightRight;
                    node.LeftChild = bufRightLeft;
                    Add(bufLeft, node);
                }
            }
        }
        public void PrintTree()
        {
            PrintTree(Root);
        }
        private void PrintTree(TreeNode startNode, string indent = "")
        {
            if (startNode != null)
            {
                var nodeSide = "";
                if (startNode.ParentNode == null)
                {
                    nodeSide = "+";
                }
                else if (startNode == startNode.ParentNode.LeftChild)
                {
                    nodeSide = "L";
                }
                else if (startNode == startNode.ParentNode.RightChild)
                {
                    nodeSide = "R";
                }
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Value}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftChild, indent);
                PrintTree(startNode.RightChild, indent);
            }
        }

        public TreeNode BFS(int value)
        {
            Queue<TreeNode> Q = new Queue<TreeNode>();
            Q.Enqueue(Root);

            while (Q.Count > 0)
            {
                foreach (var node in Q)
                {
                    Console.Write(node.Value + " ");
                }

                Console.WriteLine();

                TreeNode tmp = Q.Dequeue();
                if (tmp.Value == value)
                {
                    return tmp;
                }
                else
                {
                    if (tmp.LeftChild != null && tmp.RightChild != null)
                    {
                        Q.Enqueue(tmp.LeftChild);
                        Q.Enqueue(tmp.RightChild);
                    }
                    else if (tmp.LeftChild != null && tmp.RightChild == null)
                    {
                        Q.Enqueue(tmp.LeftChild);
                    }
                    else if (tmp.LeftChild == null && tmp.RightChild != null)
                    {
                        Q.Enqueue(tmp.RightChild);
                    }
                }
            }
            return null;
        }

        public TreeNode DFS(int value)
        {
            Stack<TreeNode> S = new Stack<TreeNode>();
            S.Push(Root);

            while (S.Count > 0)
            {
                foreach (var node in S)
                {
                    Console.Write(node.Value + " ");
                }

                Console.WriteLine();

                TreeNode tmp = S.Pop();
                if (tmp.Value == value)
                {
                    return tmp;
                }
                else
                {
                    if (tmp.LeftChild != null && tmp.RightChild != null)
                    {
                        S.Push(tmp.RightChild);
                        S.Push(tmp.LeftChild);
                    }
                    else if (tmp.LeftChild != null && tmp.RightChild == null)
                    {
                        S.Push(tmp.LeftChild);
                    }
                    else if (tmp.LeftChild == null && tmp.RightChild != null)
                    {
                        S.Push(tmp.RightChild);
                    }
                }
            }
            return null;
        }
    }
}
