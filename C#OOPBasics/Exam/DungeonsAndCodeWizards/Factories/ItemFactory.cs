using System;
using System.Linq;
using System.Reflection;
using DungeonsAndCodeWizards.Entities.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
        	var type = Assembly.GetExecutingAssembly()
        	  .GetTypes()
        	  .FirstOrDefault(t => t.Name == name);

        	if (type == null)
        	{
        		throw new ArgumentException($"Invalid item \"{name}\"!");
        	}

        	var item = (Item)Activator.CreateInstance(type);
        	return item;
        }
    }
}
