using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：BinaryTreeTest  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/30 17:22:42
// ================================
namespace Assets.JackCheng.BinaryTree
{
    public class BinaryTreeTest : MonoBehaviour
    {
        BinaryTree bt = new BinaryTree();


        void TestInsertHeap()
        {
            int i = 0;

            if (null != bt.Nodes)
            {
                bt.InsertHeap(50);
                bt.InsertHeap(100);
                bt.InsertHeap(200);
            }
            Debug.Log("\n  InsertHeap: ");
            for (i = 0; i < bt.Nodes.Count; i++)
            {
                Debug.Log(bt.Nodes[i].Val + "  ");
            }
        }

        void TestDelMinHeap()
        {
            Debug.Log("\n  DelMin: ");
            while (bt.Nodes.Count > 0)
            {
                Debug.Log(bt.DelMinHeap().Val);
            }
        }

        void TestBuildHeap()
        {
            int i = 0;

            int[] x = new int[] { 4, 5, 2, 1};
            bt.BuildHeap(x);
            Debug.Log("\n  BuildHeap:");
            for (i = 0; i < bt.Nodes.Count; i++)
            {
                Debug.Log(bt.Nodes[i].Val);
            }

        }


        void Start()
        {
            TestBuildHeap();
            TestDelMinHeap();
        }
    }
}
