using System;
using System.Linq;
using System.Reflection;
using Forum.App.Contracts;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type menuType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == menuName);

            if (menuType == null)
            {
                throw new InvalidOperationException($"{menuName} not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuType} is not an IMenu!");
            }

            ParameterInfo[] ctorParams = menuType.GetConstructors().First().GetParameters();

            object[] args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, args);

            return menu;
        }
    }
}