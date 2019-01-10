using System.Collections.Generic;

namespace GenericBox
{
    public class Box<T>
    {
        private List<T> data;
        
        public T Value { get; set; }
        

        public void Add(T value)
        {
            this.data.Add(value);
        }

        public override string ToString()
        {
            var result = $"{this.Value.GetType().FullName}: {this.Value}".TrimEnd();

            return result;
        }
    }
}
