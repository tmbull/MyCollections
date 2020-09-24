using Xunit;

namespace MyCollections.Test
{
    public class LinkedListTest
    {
        [Fact]
        public void AppendWorks()
        {
            var arr = new int[] {1, 2, 3, 4, 5};
            var list = new LinkedList<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);
            
            Assert.Equal(arr, list.ToArray());
        }
    }
}