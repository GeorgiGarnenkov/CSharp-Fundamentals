using System;
using KingGambit.Interfaces;

namespace KingGambit.Units
{
    public abstract class Soldier : IPerson
    {
        public Soldier(string name, IWriter writer)
        {
            this.Name = name;
            this.Writer = writer;
        }

        public string Name { get; private set; }

        protected IWriter Writer { get; private set; }

        public abstract void KingUnderAttack(object sender, EventArgs e);
    }
}