using System.Linq;
using System.Reflection;
using BindingFlags = System.Reflection.BindingFlags;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            // Getting class..
            Type blackBox = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");

            // Getting private field..
            FieldInfo innerValue = blackBox.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            // Getting all methods..
            MethodInfo[] methods = blackBox.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            // Getting instance of class..
            object instance = Activator.CreateInstance(blackBox, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split('_');

                string methodName = args[0];
                int value = int.Parse(args[1]);

                // Get method with given name..
                MethodInfo method = methods.First(m => m.Name == methodName);

                // Calling method with parameters..
                method.Invoke(instance, new object[] { value });
                
                Console.WriteLine(innerValue.GetValue(instance));
            }
        }
    }
}
