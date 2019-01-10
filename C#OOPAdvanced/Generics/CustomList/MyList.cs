namespace CustomList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MyList<T> 
    where T : IComparable<T>
    {
        public MyList()
        {
            this.Data = new List<T>();
        }

        public List<T> Data { get; }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public void Remove(int index)
        {
            this.Data.RemoveAt(index);
        }

        public bool Contains(T element)
        {
            if (Data.Contains(element))
            {
                return true;
            }

            return false;
        }

        private T GetElementAt(int index)
        {
            return this.Data[index];
        }

        public void Swap(int index1, int index2)
        {
            var element1 = this.GetElementAt(index1);
            var element2 = this.GetElementAt(index2);

            Data.RemoveAt(index1);
            Data.Insert(index1, element2);
            Data.RemoveAt(index2);
            Data.Insert(index2, element1);
        }
        
        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (T d in this.Data)
            {
                int i = d.CompareTo(element);

                if (i > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            T element = Data.Max();
            return element;
        }

        public T Min()
        {
            T element = Data.Min();
            return element;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T element in this.Data)
            {
                sb.AppendLine(element.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
