using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarayTree
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> root { get; set; }

        public void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }
    }

    public class BST<T>
    {
        private BinaryTreeNode<T> root = null;
        private Comparer<T> comparer = Comparer<T>.Default;


        public void Insert(T val)
        {
            BinaryTreeNode<T> node = root;
            if(node ==null)
            {
                root = new BinaryTreeNode<T>(val);
                return;
            }

            while(node !=null)
            {
                int result = comparer.Compare(node.Data, val);
                if(result ==0)
                {
                    return;
                }
                else if (result > 0)
                {
                    if(node.Left ==null)
                    {
                        node.Left = new BinaryTreeNode<T>(val);
                        return;
                    }
                    node = node.Left;
                }
                else
                {
                    if(node.Right==null)
                    {
                        node.Right = new BinaryTreeNode<T>(val);
                        return;
                    }
                    node = node.Right;
                }
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderRecursive(root);
        }

        private void PreOrderRecursive(BinaryTreeNode<T> node)
        {
            if (node == null) return;
            Console.WriteLine(node.Data);
            PreOrderRecursive(node.Left);
            PreOrderRecursive(node.Right);
        }
    }

}
