using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MyCollections
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private class Node
        {
            public Node(T value, Node? left = null, Node? right = null)
            {
                Value = value;
                Left = left;
                Right = right;
            }

            public T Value { get; }

            public Node? Left;

            public Node? Right;
        }

        private Node? _root;
        
        public BinarySearchTree()
        {
            _root = null;
        }
        public BinarySearchTree(T root)
        {
            _root = new Node(root);
        }

        public void Insert(T value)
        {
            InsertRecursive(ref _root, value);
        }

        private static void InsertRecursive(ref Node? current, T value)
        {
            if (current == null)
            {
                current = new Node(value);
                return;
            }

            var comparison = Comparer<T>.Default.Compare(value, current.Value);
            if (comparison < 0)
            {
                InsertRecursive(ref current.Left, value);
            } 
            else if (comparison > 0)
            {
                InsertRecursive(ref current.Right, value);
            }
        }

        public bool Search(T value)
        {
            var comparer = Comparer<T>.Default;
            var current = _root;
            while (current != null)
            {
                var comparison = comparer.Compare(value, current.Value);
                if (comparison == 0)
                {
                    return true;
                }

                current = comparison < 0 ? current.Left : current.Right;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator(_root);
        }
        
        private IEnumerator<T> GetEnumerator(Node? current)
        {
            if (current == null)
            {
                yield break;
            }
            var stack = new Stack<Node>();
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    yield return current.Value;
                    current = current.Right;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public IEnumerable<T> EnumeratePreOrder()
        {
            if (_root == null)
            {
                yield break;
            }

            var stack = new Stack<Node>();
            stack.Push(_root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current.Value;
                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }
        }
        
        public IEnumerable<T> EnumeratePostOrder()
        {
            if (_root == null)
            {
                yield break;
            }

            var stack = new Stack<Node>();
            var current = _root;
            Node? lastVisited = null;
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    var peek = stack.Peek();
                    if (peek?.Right != null && lastVisited != peek.Right)
                    {
                        current = peek.Right;
                    }
                    else
                    {
                        lastVisited = stack.Pop();
                        yield return lastVisited.Value;
                    }
                }
            }
        }
    }
}