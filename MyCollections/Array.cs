using System;

namespace MyCollections
{
    // TODO: This in an unmanaged language
    public class Array<T>
    {
        private T[] _bytes;
        private IntPtr _bytePtr;
        
        public Array(int size)
        {
            _bytes = new T[size];
        }

        public T this[int index]
        {
            get
            {
                return _bytes[index];   
            }
        }
    }
}
