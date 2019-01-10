using System.Collections.Generic;
using System.Linq;
using KingGambit.Interfaces;
using KingGambit.Units;

namespace KingGambit
{
    public class Engine
    {
        private King king;
        private List<Soldier> soldiers;

        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.soldiers = new List<Soldier>();
        }

        public void Run()
        {
            this.BuildKingdom();
            this.ExecuteCommands();
        }

        private void ExecuteCommands()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "End")
            {
                var args = input.Split();
                var command = args[0];

                switch (command)
                {
                    case "Attack":
                        this.king.OnUnderAttack();
                        break;
                    case "Kill":
                        this.RemoveDeadSoldier(args[1]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void RemoveDeadSoldier(string soldierName)
        {
            var soldier = this.soldiers.FirstOrDefault(s => s.Name == soldierName);
            this.king.UnderAttack -= soldier.KingUnderAttack;
            this.soldiers.Remove(soldier);
        }

        private void BuildKingdom()
        {
            var kingName = this.reader.ReadLine();
            this.king = new King(kingName, this.writer);

            var royalGuardNames = this.reader.ReadLine().Split();
            foreach (var name in royalGuardNames)
            {
                var royalGuard = new RoyalGuard(name, this.writer);

                this.soldiers.Add(royalGuard);

                this.king.UnderAttack += royalGuard.KingUnderAttack;
            }

            var footmanNames = this.reader.ReadLine().Split();
            foreach (var name in footmanNames)
            {
                var footman = new Footman(name, this.writer);

                this.soldiers.Add(footman);

                this.king.UnderAttack += footman.KingUnderAttack;
            }
        }
    }
}