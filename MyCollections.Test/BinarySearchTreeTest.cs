using System.Linq;
using Xunit;

namespace MyCollections.Test
{
    public class BinarySearchTreeTest
    {
        [Theory]
        [InlineData(new int[]{})]
        [InlineData(new[]{1,2,3,4})]
        [InlineData(new[]{-1,1,1,2,3,4,2,1})]
        [InlineData(new[]{1,1,1,1})]
        [InlineData(new[]{2,23,42,34,234,23,42,34,234,3,5,4,3,543,1,45,2,34,3,13,2,3,213,3,42,3,2,34,23,1,32,2,22,2,2})]
        [InlineData(new[]{-6,-6,-7,2,2,1,3,4,3,5,4,3,0,3,2,3,3,4,4,128,5,5,6,6,6,7,7,7,77,99})]
        public void InsertWorksAndThereAreNoDups(int[] input)
        {
            var tree = new BinarySearchTree<int>();
            foreach (var i in input)
            {
                tree.Insert(i);
            }

            var set = input.ToHashSet();
            Assert.Equal(set.Count, tree.ToArray().Length);
            Assert.All(tree, i => Assert.Contains(i, set));
        }

        [Theory]
        [InlineData(new int[]{})]
        [InlineData(new[]{1,2,3})]
        [InlineData(new[]{3,2,1})]
        [InlineData(new[]{10,42,5,-1,8,16,73,123,7567,34,1234,453,5345,-42,654,6542,243,-111,235,2,6,7})]
        public void EnumerableIsInOrder(int[] input)
        {
            var tree = new BinarySearchTree<int>();
            foreach (var i in input)
            {
                tree.Insert(i);
            }
            
            Assert.Equal(input.OrderBy(i => i), tree.ToArray());
        }

        [Theory]
        [InlineData(new int[]{}, 7, false)]
        [InlineData(new[]{1,2,3}, 2, true)]
        [InlineData(new[]{1,2,3}, 7, false)]
        [InlineData(new[]{1,2,3,34,3,23,4,3,2,34,2,35,1,23,123,132,-1-12-3,123,-3,1-32-3,123,12,-123,4}, 123, true)]
        [InlineData(new[]{1,1,1,1,1,1,1}, 1, true)]
        public void SearchWorks(int[] elements, int elem, bool exists)
        {
            var tree = new BinarySearchTree<int>();
            foreach (var i in elements)
            {
                tree.Insert(i);
            }
            
            Assert.Equal(exists, tree.Search(elem));
        }
        
        [Theory]
        [InlineData(new char[]{}, new char[]{})]
        [InlineData(new[]{'A', 'B', 'C'}, new[]{'A', 'B', 'C'})]
        [InlineData(new[]{'C', 'B', 'A'}, new[]{'C', 'B', 'A'})]
        [InlineData(new[]{'F', 'B', 'G', 'A', 'D', 'I', 'C', 'E', 'H'}, new[]{'F', 'B', 'A', 'D', 'C', 'E', 'G', 'I', 'H'})]
        public void CanEnumeratePreOrder(char[] elements, char[] result)
        {
            var tree = new BinarySearchTree<char>();
            foreach (var i in elements)
            {
                tree.Insert(i);
            }
            
            Assert.Equal(result, tree.EnumeratePreOrder());
        }
        
        [Theory]
        [InlineData(new char[]{}, new char[]{})]
        [InlineData(new[]{'A', 'B', 'C'}, new[]{'C', 'B', 'A'})]
        [InlineData(new[]{'C', 'B', 'A'}, new[]{'A', 'B', 'C'})]
        [InlineData(new[]{'F', 'B', 'G', 'A', 'D', 'I', 'C', 'E', 'H'}, new[]{'A', 'C', 'E', 'D', 'B', 'H', 'I', 'G', 'F'})]
        public void CanEnumeratePostOrder(char[] elements, char[] result)
        {
            var tree = new BinarySearchTree<char>();
            foreach (var i in elements)
            {
                tree.Insert(i);
            }
            
            Assert.Equal(result, tree.EnumeratePostOrder());
        }
    }
}