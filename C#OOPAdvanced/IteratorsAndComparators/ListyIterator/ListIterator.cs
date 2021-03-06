﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListIterator<T>
    {
        private readonly List<T> collection;
        private int currentIndex;

        public ListIterator(ICollection<T> collection)
        {
            this.collection = new List<T>(collection);
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (this.currentIndex < this.collection.Count - 1)
            {
                this.currentIndex++;
                return true;
            }

            return false;

        }

        public bool HasNext()
        {
            if (this.currentIndex < this.collection.Count - 1)
            {
                return true;
            }

            return false;
        }

        public T Print()
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Invalid Operation!");
            }

            return this.collection[currentIndex];
        }
    }
}
