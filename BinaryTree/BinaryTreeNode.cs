using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：BinaryTreeNode  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/30 16:14:45
// ================================
namespace Assets.JackCheng.BinaryTree
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int _val) { this.Val = _val; }

        ~BinaryTreeNode() { }
        public BinaryTreeNode parent;

        public BinaryTreeNode left;

        public BinaryTreeNode right;

        private int val;
        public int Val
        {
            set { val = value; }
            get { return val; }
        }
    }
}
