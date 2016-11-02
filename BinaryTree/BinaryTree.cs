using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：BinaryTree  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/30 16:14:14
// ================================
namespace Assets.JackCheng.BinaryTree
{
    public class BinaryTree
    {

        private List<BinaryTreeNode> nodes;

        public List<BinaryTreeNode> Nodes
        {
            get
            {
                return this.nodes;
            }
        }
        public BinaryTree()
        {
            nodes = new List<BinaryTreeNode>();

        }

        ~BinaryTree() { }

        /// <summary>
        /// 下滤操作(第n的节点的子节点位置为 2*n+1 和 2*n+2 )
        /// </summary>
        public void PercolateDown(int idx)
        {
            int root = idx;
            int left = idx * 2 + 1;
            int right = left + 1;
            int min = 0;
            while (left < this.nodes.Count)
            {
                min = left;
                if (right < this.nodes.Count && nodes[left].Val > nodes[right].Val)
                    min = right;
                if (nodes[min].Val < nodes[root].Val)
                {
                    BinaryTreeNode temp = nodes[root];
                    nodes[root] = nodes[min];
                    nodes[min] = temp;
                    //继续调整直到满足小堆条件
                    root = min;
                    left = root * 2 + 1;
                    right = left + 1;
                }
                else
                    break;
            }

        }
       /// <summary>
        /// 上滤操作 
       /// </summary>
       /// <param name="idx"></param>
        public void PercolateUp(int idx)
        {
            int child = idx;
            //计算插入结点的父结点
            int root = (child - 1) / 2;
            //一直向上调整直到根结点的值小于左右结点
            while (root > 0)
            {
                if (nodes[child].Val < nodes[root].Val)
                {
                    BinaryTreeNode temp = nodes[child];
                    nodes[child] = nodes[root];
                    nodes[root] = temp;

                    child = root;
                    root = (child - 1) / 2;
                }
                else
                    break;
            }
            if (nodes[child].Val < nodes[root].Val && root == 0)
            {
                BinaryTreeNode temp = nodes[child];
                nodes[child] = nodes[root];
                nodes[root] = temp;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<BinaryTreeNode> InsertHeap(int value)
        {
            BinaryTreeNode newNode = new BinaryTreeNode(value);
            nodes.Add(newNode);
            PercolateUp(nodes.Count - 1);

            return nodes;
        }

        /// <summary>
        /// 删除最小值
        /// </summary>
        public BinaryTreeNode DelMinHeap()
        {
            //检查堆中是否还有元素
            if (nodes.Count == 0)
            {
                Debug.Log("empty array" );
                return null;
            }
            BinaryTreeNode temp = nodes[0];
            //将最后一个结点的值给第一个结点，并删除最后一个结点
            nodes[0] = nodes[nodes.Count - 1];
            nodes.RemoveAt(nodes.Count - 1);
            PercolateDown(0);       //重新调整

            return temp;
        }

        /// <summary>
        /// 从数组中建立堆的例程 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public List<BinaryTreeNode> BuildHeap(int[] x)
        {
            int i = 0;
            int n = x.Length;
            InitHeap(n);      /* include ele[0]=0 */

            for (i = 0; i < n; i++)
            {
                nodes[i].Val = x[i];
            }
            for (i = n / 2 - 1; i >= 0; i--)
            {
                PercolateDown(i);
            }

            return nodes;
        }

       /// <summary>
       /// 初始化
       /// </summary>
       /// <param name="max_ele"></param>
       /// <returns></returns>
        public List<BinaryTreeNode> InitHeap(int max_ele)
        {
            if (nodes != null)
            {
                nodes.Clear();
            }
            else
            {
                nodes = new List<BinaryTreeNode>();
            }
            for (int i = 0; i < max_ele; i++)
            {
                nodes.Add(new BinaryTreeNode(0));
            }
            
            return nodes;
        }


    }
}
