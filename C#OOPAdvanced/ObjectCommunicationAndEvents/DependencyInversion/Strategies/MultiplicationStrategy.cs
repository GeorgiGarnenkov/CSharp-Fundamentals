using DependencyInversion.Interfaces;

namespace DependencyInversion.Strategies
{
    public class MultiplicationStrategy: IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}