using System;
using System.Linq;
using Xunit;

namespace MyCollections.Test
{
    public class LinkedListTest
    {
        [Fact]
        public void ToArrayWorks_EmptyList()
        {
            var arr = new int[0];
            var list = new LinkedList<int>();

            
            Assert.Equal(arr, list.ToArray());
        }
        
        [Fact]
        public void FromArrayWorks_EmptyList()
        {
            var list = new LinkedList<int>();
            var arr = list.ToArray();
            
            Assert.Equal(new int[0], arr);
        }
        
        [Fact]
        public void FromArrayWorks()
        {
            var arr = new[] {4, 5, 6};
            var list = LinkedList<int>.FromArray(arr);
            
            Assert.Equal(arr, list.ToArray());
        }
        
        [Fact]
        public void AppendWorks()
        {
            var arr = new[] {1, 2, 3, 4, 5};
            var list = new LinkedList<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);
            
            Assert.Equal(arr, list.ToArray());
        }
        
        [Fact]
        public void InsertWorks()
        {
            var arr = new[] {1, 0, 2, 0, 3, 0, 4, 0, 5};
            var list = LinkedList<int>.FromArray(new[] {1, 2, 3, 4, 5});
            list.Insert(0, 3);
            list.Insert(0,2);
            list.Insert(0, 1);
            list.Insert(0, 0);

            Assert.Equal(arr, list.ToArray());
        }
        
        [Fact]
        public void PrependWorks()
        {
            var arr = new[] {5, 4, 3, 2, 1};
            var list = new LinkedList<int>();
            list.Prepend(1);
            list.Prepend(2);
            list.Prepend(3);
            list.Prepend(4);
            list.Prepend(5);
            
            Assert.Equal(arr, list.ToArray());
        }
        
        [Fact]
        public void RemoveAtIndexWorks()
        {
            var list = LinkedList<int>.FromArray(new[] {1, 2, 3, 4, 5});
            list.RemoveAtIndex(0);
            list.RemoveAtIndex(3);
            
            Assert.Equal(new[] {2, 3, 4}, list.ToArray());
        }
                
        [Fact]
        public void RemoveAtIndex_ThrowsArgumentException()
        {
            var list = LinkedList<int>.FromArray(new[] {1, 2, 3, 4, 5});
            
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAtIndex(5));
        }
        
        [Fact]
        public void RemoveAtIndexFromEnd_LastElementWorks()
        {
            var list = LinkedList<int>.FromArray(new[] {1, 2, 3, 4, 5});
            list.RemoveAtIndexFromEnd(0);
            
            Assert.Equal(new[] {1, 2, 3, 4}, list.ToArray());
        }
        
        [Fact]
        public void RemoveAtIndexFromEnd_MiddleElementWorks()
        {
            var list = LinkedList<int>.FromArray(new[] {1, 2, 3, 4, 5});
            list.RemoveAtIndexFromEnd(2);
            
            Assert.Equal(new[] {1, 2, 4, 5}, list.ToArray());
            int[] tmp = new[] {1, 2, 3};
            tmp.Select(t => new Tmp(t)).Where(t => t.Foo < 5).Min(t => t.Foo);
        }

        class Tmp
        {
            public int Foo;

            public Tmp(int foo)
            {
                Foo = foo;
            }
        }
        
        [Fact]
        public void RemoveAtIndexFromEnd_FirstElementWorks()
        {
            var list = LinkedList<int>.FromArray(new[] {1, 2, 3, 4, 5});
            list.RemoveAtIndexFromEnd(4);
            
            Assert.Equal(new[] {2, 3, 4, 5}, list.ToArray());
        }
    }
}