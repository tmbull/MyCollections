using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollections
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Value { get; }
            public Node? Next { get; set; }

            public Node(T value, Node? next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node? _head;
        public int Count { get; private set; }


        public LinkedList()
        {
            Count = 0;
            _head = null;
        }

        public LinkedList(T first)
        {
            Count = 1;
            _head = new Node(first, null);
        }

        public void Prepend(T value)
        {
            var current = _head;
            _head = new Node(value, current);
            Count++;
        }

        public void Append(T value)
        {
            Insert(value, Count - 1);
        }
        
        public void Insert(T value, int index)
        {
            if (index == -1)
            {
                Prepend(value);
                return;
            }
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
            Count++;
        }
        
        public T RemoveAtIndex(ref int index) {
            int idx = 0;
            var current = _head;
            while (idx < index && current?.Next != null) {
                current = current.Next;
                idx++; // 1 // 2
            }
        
            _head = current?.Next;
            if (current != null)
            {
                current.Next = null;
                Count--;
                return current.Value;
            }
            
            throw new ArgumentOutOfRangeException($"{index} is out of range.");
        }
        
        public void RemoveAtIndexFromEnd(ref int index) {
            var count = 1;
            if (_head == null)
            {
                throw new ArgumentOutOfRangeException($"{index} is out of range."); 
            }
            RemoveRecursive(_head, index, ref count);
            Count--;
        }
    
        private static void RemoveRecursive(Node head, int n, ref int count) {
            var currentIdx = count;
            if (head.Next != null) {
                count++;
                RemoveRecursive(head.Next, n, ref count);
            }
        
            if (currentIdx == count - n) {
                head.Next = head.Next?.Next;
            }
        }

        public T[] ToArray()
        {
            var arr = new T[Count];
            var i = 0;
            foreach (var t in this)
            {
                arr[i] = t;
                i++;
            } 

            return arr;
        }

        public static LinkedList<T> FromArray(T[] arr)
        {
            var result = new LinkedList<T>();
            
            for (var i = 0; i < arr.Length; i++)
            {
                result.Append(arr[i]);
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}