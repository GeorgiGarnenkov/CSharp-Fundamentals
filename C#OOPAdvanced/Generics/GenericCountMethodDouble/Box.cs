using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box<T>
    where T : IComparable<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T value)
        {
            this.data.Add(value);
        }

        public void Swap(int index1, int index2)
        {
            var element1 = this.GetElementAt(index1);
            var element2 = this.GetElementAt(index2);

            data.RemoveAt(index1);
            data.Insert(index1, element2);
            data.RemoveAt(index2);
            data.Insert(index2, element1);
        }

        public int CountOfBiggerElements(Box<T> data, T element) 
        {
            int countOfElements = 0;

            foreach (T d in data)
            {
                int i = d.CompareTo(element);

                if (i > 0)
                {
                    countOfElements++;
                }
            }
            return countOfElements;
        }
        

        public T GetElementAt(int index)
        {
            return this.data[index];
        }

        public IEnumerator GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in data)
            {
                sb.AppendLine($"{value.GetType().FullName}: {value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}