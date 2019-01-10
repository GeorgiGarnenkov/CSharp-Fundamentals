using DependencyInversion.Interfaces;
using DependencyInversion.Strategies;

namespace DependencyInversion.Models
{
    public class PrimitiveCalculator : IPrimitiveCalculator
    {
        private IStrategy calculationStrategy;

        public PrimitiveCalculator()
            : this(new AdditionStrategy())
        {
        }

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.calculationStrategy = strategy;
        }


        public void ChangeStrategy(IStrategy strategy)
        {
            this.calculationStrategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.calculationStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}
