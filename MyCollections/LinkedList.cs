using System;

namespace MyCollections
{
    public class LinkedList<T>
    {
        private class Node
        {
            private T _value;
            public Node? Next { get; set; }

            public Node(T value, Node? next)
            {
                _value = value;
                Next = next;
            }
        }

        private Node? _head;
        public int Count { get; }


        public LinkedList()
        {
            _head = null;
        }

        public LinkedList(T first)
        {
            _head = new Node(first, null);
        }

        public void Prepend(T value)
        {
            var current = _head;
            _head = new Node(value, current);
        }

        public void Append(T value)
        {
            Insert(value, Count - 1);
        }
        
        public void Insert(T value, int index)
        {
            int i = 0;
            var current = _head;
            while (i < index && current != null)
            {
                i++;
                current = current.Next;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException($"{index} is out of range.");
            }

            var next = current.Next;
            current.Next = new Node(value, next);
        }
        
    }
}