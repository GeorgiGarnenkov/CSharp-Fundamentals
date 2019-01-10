using System;
using System.Linq;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    /// <summary>
    /// by g0shk0
    /// </summary>
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IFestivalController festivalCоntroller;
        private readonly ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine()) != "END") // for job security
            {
                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex) // in case we run out of memory
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);

        }

        public string ProcessCommand(string input)
        {
            var args = input.Split();

            var command = args[0];
            var parameters = args.Skip(1).ToArray();

            string returnString = null;
            switch (command)
            {
                case "LetsRock":
                    returnString = this.setCоntroller.PerformSets();
                    break;
                case "RegisterSet":
                    returnString = this.festivalCоntroller.RegisterSet(parameters);
                    break;
                case "SignUpPerformer":
                    returnString = this.festivalCоntroller.SignUpPerformer(parameters);
                    break;
                case "RegisterSong":
                    returnString = this.festivalCоntroller.RegisterSong(parameters);
                    break;
                case "AddSongToSet":
                    returnString = this.festivalCоntroller.AddSongToSet(parameters);
                    break;
                case "AddPerformerToSet":
                    returnString = this.festivalCоntroller.AddPerformerToSet(parameters);
                    break;
                case "RepairInstruments":
                    returnString = this.festivalCоntroller.RepairInstruments(parameters);
                    break;
                default:
                    break;
            }

            return returnString;
        }
    }
}