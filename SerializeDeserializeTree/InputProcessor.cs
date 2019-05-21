using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SerializeDeserializeTree
{
    class InputProcessor
    {
        public static BinaryTree ConstructTreeFromInput() {
            BinaryTree binaryTree = new BinaryTree(null);

            Console.WriteLine("Enter the number of nodes in the binary tree");
            try{
                int numberOfNodes = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the elements separated by space, comma or" +
                    " semi-colon");
                String[] elements = Console.ReadLine().Split(' ',',',';');
                for (int index = 0; index < numberOfNodes; index++)
                {
                    binaryTree.SetBinaryTreeRoot(
                        binaryTree.Insert(binaryTree.GetBinaryTreeRoot(), int.Parse(elements[index])));
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
            return binaryTree;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void SerializeBinaryTree(BinaryTreeNode binaryTreeNode) {

            try
            {
                FileStream fileStream = new FileStream("D:\\SerializeTreeFile.txt", FileMode.OpenOrCreate);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                _SerializeBinaryTree(binaryTreeNode, streamWriter);
                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void _SerializeBinaryTree(BinaryTreeNode binaryTreeNode, StreamWriter streamWriter) {
            if (binaryTreeNode == null)
            {                
                streamWriter.WriteLine("-1");
                return;
            }
            streamWriter.WriteLine(binaryTreeNode.GetBinaryTreeNodeData()+"");
            _SerializeBinaryTree(binaryTreeNode.GetBinaryTreeNodeLeft(), streamWriter);
            _SerializeBinaryTree(binaryTreeNode.GetBinaryTreeNodeRight(), streamWriter);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static BinaryTreeNode DeserializeBinaryTree(BinaryTreeNode binaryTreeNode) {
            try
            {
                FileStream fileStream = new FileStream("D:\\SerializeTreeFile.txt", FileMode.OpenOrCreate);
                StreamReader streamReader= new StreamReader(fileStream);
                return _DeserializeBinaryTree(binaryTreeNode, streamReader);
                streamReader.Close();
                fileStream.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Thrown exception is " + exception.Message);
            }
            return null;
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        private static BinaryTreeNode _DeserializeBinaryTree(BinaryTreeNode binaryTreeNode, StreamReader streamReader) {
            String s = streamReader.ReadLine();
            if (s == "-1") {
                return null;
            }

            binaryTreeNode = new BinaryTreeNode(int.Parse(s));
            binaryTreeNode.SetBinaryTreeNodeLeft(
            _DeserializeBinaryTree(binaryTreeNode.GetBinaryTreeNodeLeft(), streamReader));
            binaryTreeNode.SetBinaryTreeNodeRight(
            _DeserializeBinaryTree(binaryTreeNode.GetBinaryTreeNodeRight(), streamReader));
            return binaryTreeNode;
        }
    }
}
