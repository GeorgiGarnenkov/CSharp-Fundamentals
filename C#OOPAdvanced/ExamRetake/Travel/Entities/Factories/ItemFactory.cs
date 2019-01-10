using System;
using System.Linq;
using System.Reflection;

namespace Travel.Entities.Factories
{
	using Contracts;
	using Items.Contracts;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
		    var itemType = Assembly.GetCallingAssembly().GetTypes()
		        .Where(t => typeof(IItem).IsAssignableFrom(t))
		        .FirstOrDefault(t => t.Name == type);

		    var item = (IItem)Activator.CreateInstance(itemType);

		    return item;
		}
	}
}
