using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeDeserializeTree
{
    class BinaryTreeNode
    {
        int data;
        BinaryTreeNode left;
        BinaryTreeNode right;

        public BinaryTreeNode(int data) {
            this.data = data;
        }

        public void SetBinaryTreeNodeData(int data) {
            this.data = data;
        }

        public void SetBinaryTreeNodeLeft(BinaryTreeNode binaryTreeNode) {
            left = binaryTreeNode;
        }

        public void SetBinaryTreeNodeRight(BinaryTreeNode binaryTreeNode) {
            right = binaryTreeNode;
        }

        public int GetBinaryTreeNodeData() {
            return data;
        }

        public BinaryTreeNode GetBinaryTreeNodeLeft() {
            return left;
        }

        public BinaryTreeNode GetBinaryTreeNodeRight() {
            return right;
        }
    }
}
