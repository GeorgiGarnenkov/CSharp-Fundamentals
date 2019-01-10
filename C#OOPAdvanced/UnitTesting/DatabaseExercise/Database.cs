using System;

namespace DatabaseExercise
{
    public class Database
    {
        private const int ArrayCap = 16;

        private int[] integers;
        private int currentIndex;

        private Database()
        {
            this.integers = new int[ArrayCap];
            this.currentIndex = 0;
        }

        public Database(params int[] inputIntegers)
            : this()
        {
            this.InitializeIntegers(inputIntegers);
        }

        private void InitializeIntegers(int[] inputIntegers)
        {
            try
            {
                //inputIntegers = inputIntegers.Concat(inputIntegers).ToArray();
                Array.Copy(inputIntegers, this.integers, inputIntegers.Length);
                this.currentIndex = inputIntegers.Length;
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException("Array is full", e);
            }

        }

        public void Add(int element)
        {
            if (this.currentIndex >= ArrayCap)
            {
                throw new InvalidOperationException("Array is full!");
            }

            this.integers[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }

            this.currentIndex--;

            this.integers[this.currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            int[] newArray = new int[this.currentIndex];
            Array.Copy(this.integers, newArray, this.currentIndex);

            return newArray;
        }
    }
}