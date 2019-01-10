using System;
using KingGambit.Interfaces;

namespace KingGambit.Units
{
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name, IWriter writer) 
            : base(name, writer)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs e)
        {
            this.Writer.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}