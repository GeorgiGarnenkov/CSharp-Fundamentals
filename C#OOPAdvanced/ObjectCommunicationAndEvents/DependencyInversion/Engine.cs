using System;
using System.Collections.Generic;
using DependencyInversion.Interfaces;
using DependencyInversion.Strategies;

namespace DependencyInversion
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private IDictionary<char, IStrategy> symbolicStrategyMapper;
        private IPrimitiveCalculator calculator;

        public Engine(IPrimitiveCalculator calculator, IReader reader, IWriter writer)
            : this(calculator, reader, writer, new Dictionary<char, IStrategy>())
        {
            this.SetDefaultSymbolicStrategyMapper();
        }

        public Engine(IPrimitiveCalculator calculator, IReader reader, IWriter writer, IDictionary<char, IStrategy> symbolicStrategyMapper)
        {
            this.calculator = calculator;
            this.reader = reader;
            this.writer = writer;
            this.symbolicStrategyMapper = symbolicStrategyMapper;
        }


        public void Run()
        {
            this.ExecuteCommands();
        }

        private void ExecuteCommands()
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                var args = input.Split();
                var command = args[0];

                if (command.Equals("mode", StringComparison.OrdinalIgnoreCase))
                {
                    var newStrategy = this.symbolicStrategyMapper[args[1][0]];
                    this.calculator.ChangeStrategy(newStrategy);
                }
                else
                {
                    var firstOperand = int.Parse(command);
                    var secondOperand = int.Parse(args[1]);
                    var result = this.calculator.PerformCalculation(firstOperand, secondOperand);
                    this.writer.WriteLine(result.ToString());
                }
                
            }
        }

        private void SetDefaultSymbolicStrategyMapper()
        {
            this.symbolicStrategyMapper['+'] = new AdditionStrategy();
            this.symbolicStrategyMapper['-'] = new SubtractionStrategy();
            this.symbolicStrategyMapper['*'] = new MultiplicationStrategy();
            this.symbolicStrategyMapper['/'] = new DivisionStrategy();
        }
    }
}