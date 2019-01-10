using System;

using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            var setType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (setType == null)
            {
                throw new ArgumentException($"Invalid set type \"{type}\"!");
            }

            ISet set = (ISet)Activator.CreateInstance(setType, name);
            
            return set;
            
        }
    }
}
