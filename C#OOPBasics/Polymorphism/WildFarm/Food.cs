using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food
    {
        private int quantity;

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
    }
}
