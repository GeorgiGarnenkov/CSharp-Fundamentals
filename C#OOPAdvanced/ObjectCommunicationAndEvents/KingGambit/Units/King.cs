using System;
using KingGambit.Interfaces;

namespace KingGambit.Units
{
    public class King : IPerson
    {
        public event EventHandler UnderAttack;

        private IWriter writer;

        public King(string name, IWriter writer)
        {
            this.Name = name;
            this.writer = writer;
        }

        public string Name { get; private set; }

        public void OnUnderAttack()
        {
            this.writer.WriteLine($"King {this.Name} is under attack!");
            this.UnderAttack?.Invoke(this, new EventArgs());
        }
    }
}