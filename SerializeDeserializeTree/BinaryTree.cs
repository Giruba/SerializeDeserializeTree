using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeDeserializeTree
{
    class BinaryTree
    {
        BinaryTreeNode root;

        public BinaryTree(BinaryTreeNode binaryTreeNode) {
            root = binaryTreeNode;
        }

        public void SetBinaryTreeRoot(BinaryTreeNode binaryTreeNode) {
            root = binaryTreeNode;
        }

        public BinaryTreeNode GetBinaryTreeRoot() {
            return root;
        }

        public BinaryTreeNode Insert(BinaryTreeNode binaryTreeNode, int data) {

            if (binaryTreeNode == null) {
                binaryTreeNode = new BinaryTreeNode(data);
                return binaryTreeNode;
            }

            if (binaryTreeNode.GetBinaryTreeNodeData() < data)
            {
                binaryTreeNode.SetBinaryTreeNodeRight(
                    Insert(binaryTreeNode.GetBinaryTreeNodeRight(), data));
            }
            else {
                binaryTreeNode.SetBinaryTreeNodeLeft(
                    Insert(binaryTreeNode.GetBinaryTreeNodeLeft(), data));
            }

            return binaryTreeNode;
        }

        public void PrintInorderTraversal(BinaryTreeNode binaryTreeNode) {
            if (binaryTreeNode == null) {
                return;
            }
            PrintInorderTraversal(binaryTreeNode.GetBinaryTreeNodeLeft());
            Console.Write(binaryTreeNode.GetBinaryTreeNodeData() + " ");
            PrintInorderTraversal(binaryTreeNode.GetBinaryTreeNodeRight());
        }
    }
}
