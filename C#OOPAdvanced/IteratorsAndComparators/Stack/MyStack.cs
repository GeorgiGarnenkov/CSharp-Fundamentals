using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly List<T> collection;
         
        public MyStack()
        {
            this.collection = new List<T>();
        }

        public void Push(IEnumerable<T> elements)
        {
            this.collection.AddRange(elements);
        }

        public void Pop()
        {
            if (this.collection.Count == 0)
            {
                throw new ArgumentException("No elements");
            }
            int lastIndex = this.collection.Count - 1;
            this.collection.RemoveAt(lastIndex);
        }
        

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.collection.Count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
    }
}
