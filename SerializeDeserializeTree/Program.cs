using System;

namespace SerializeDeserializeTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Serialize and Deserialize a Binary Tree!");
            Console.WriteLine("----------------------------------------");

            BinaryTree binaryTree = InputProcessor.ConstructTreeFromInput();

            Console.WriteLine("Constructed tree ---------------");
            binaryTree.PrintInorderTraversal(binaryTree.GetBinaryTreeRoot());
            Console.WriteLine();
            Console.WriteLine("Serializing tree -------------");
            InputProcessor.SerializeBinaryTree(binaryTree.GetBinaryTreeRoot());
            Console.WriteLine("Deserializing tree ---------------");
            BinaryTree binaryTreeNew = new BinaryTree(null);
            binaryTreeNew.SetBinaryTreeRoot(
                InputProcessor.DeserializeBinaryTree(binaryTreeNew.GetBinaryTreeRoot()));
            Console.WriteLine();
            Console.WriteLine("Deserialized binary tree is");
            binaryTreeNew.PrintInorderTraversal(binaryTree.GetBinaryTreeRoot());
            Console.ReadLine();
        }
    }
}
