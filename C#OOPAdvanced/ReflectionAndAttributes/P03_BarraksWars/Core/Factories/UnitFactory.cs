using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Get unit model..
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);
            
            IUnit unit = (IUnit)Activator.CreateInstance(model);

            return unit;
        }
    }
}
