using System;
using System.Linq;
using DungeonsAndCodeWizards.IO.Interfaces;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private readonly DungeonMaster master;

        private bool isRunning;
        private IReader reader;
        private IWriter writer;
       
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.master = new DungeonMaster();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string command = this.reader.ReadLine();
                try
                {
                    ExecuteCommands(command);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine("Parameter Error: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("Invalid Operation: " + e.Message);
                }

                if (this.master.IsGameOver() || this.isRunning == false)
                {
                    this.writer.WriteLine("Final stats:");
                    this.writer.WriteLine(this.master.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ExecuteCommands(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;

            switch (commandName)
            {
                case "JoinParty":
                    output = this.master.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = this.master.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = this.master.PickUpItem(args);
                    break;
                case "UseItem":
                    output = this.master.UseItem(args);
                    break;
                case "GiveCharacterItem":
                    output = this.master.GiveCharacterItem(args);
                    break;
                case "UseItemOn":
                    output = this.master.UseItemOn(args);
                    break;
                case "GetStats":
                    output = this.master.GetStats();
                    break;
                case "Attack":
                    output = this.master.Attack(args);
                    break;
                case "Heal":
                    output = this.master.Heal(args);
                    break;
                case "EndTurn":
                    output = this.master.EndTurn(args);
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
